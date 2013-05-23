<Query Kind="Program" />

/* Pattern: Active Object Pattern

Ref: http://www.cs.wustl.edu/~schmidt/PDF/Act-Obj.pdf

Definition: Active Object pattern, which decouples method execution from method invocation in order to
simplify synchronized access to an object that resides in its own thread of control

*/

void Main()
{
	File file = new File("Test1");
	
	FileUploadServant fileUploader = new FileUploadServant();
	MessageQueue queue = new MessageQueue(4);
	ActiveScheduler scheduler = new ActiveScheduler(queue);
	
	FileUploadServantProxy proxy = new FileUploadServantProxy(scheduler, fileUploader);
	FileUploadResponse response =  proxy.Upload(file);
	
	// manual process
	scheduler.Dispatch();
	
	Console.WriteLine("Response: {0}", response.Status);
	
}

public class File
{
	public string Name { get; set; }
	
	public File(string name)
	{
		this.Name = name;
	}
}

public enum UploadStatus
{
	IsPending,
	HasSucceeded,
	HasFailed,
	HasCancelled
}

// Servant 
public abstract class AbstractFileUploadServant
{
	public abstract UploadStatus Upload(File file);
}

public class FileUploadServant : AbstractFileUploadServant
{ 
	public override UploadStatus Upload(File file)
	{
		Console.WriteLine("Reading file {0}", file.Name);
		
		// Do work
		return UploadStatus.HasSucceeded;
	}
}

// Future
public class FileUploadResponse
{
	public UploadStatus Status { get; set; }
	public FileUploadRequest Request { get; set; }
	
	public FileUploadResponse(FileUploadRequest request)
	{
		this.Request = request;
	}
}

// MessageQueue
public class MessageQueue
{
	public int Size { get; private set; }
	
	public MessageQueue(int size)
	{
		this.Size = size;
		_queue = new Queue<FileUploadRequest>(size);
	}
	
	public void Enqueue(FileUploadRequest request)
	{
		if(IsFull() == true)
		{
			throw new Exception("Queue is full");
		}
		
		this._queue.Enqueue(request);
	}
	
	public FileUploadRequest Dequeue()
	{
		if(IsEmpty() == true)
		{
			throw new Exception("Queue is empty");
		}
		
		return this._queue.Dequeue();
	}
	
	public FileUploadRequest Peek()
	{
		if(IsEmpty() == true)
		{
			throw new Exception("Queue is empty");
		}
		
		return this._queue.Peek();
	}
	
	public bool IsEmpty()
	{
		return this._queue.Count == 0;
	}
	
	public bool IsFull()
	{
		return this._queue.Count == Size;
	}
	
	private Queue<FileUploadRequest> _queue;
}

// Message Request
public abstract class MessageRequest
{
	public abstract bool AllowInvoke();
	public abstract void Invoke();
}

public class FileUploadRequest : MessageRequest
{
	public File FileToBeUploaded { get; set; }
	public FileUploadResponse Response { get; set; }

	public FileUploadRequest(FileUploadServant fileUploader, File file)
	{
		this.FileToBeUploaded = file;
		this._fileUploader = fileUploader;
		this.Response = new FileUploadResponse(this)
				{
					Status = UploadStatus.IsPending
				};
	}
	
	public override bool AllowInvoke()
	{
		return true; 
	}
	
	public override void Invoke()
	{		
		// Call actual servant.
		this.Response.Status = this._fileUploader.Upload(this.FileToBeUploaded);
	}
	
	private FileUploadServant _fileUploader;
}

// Proxy
public class FileUploadServantProxy
{
	public FileUploadServantProxy(ActiveScheduler scheduler, FileUploadServant fileUploader)
	{
		_scheduler = scheduler;
		_fileUploader = fileUploader;
	}
	
	public FileUploadResponse Upload(File file)
	{		
		// Create message request
		_request = new FileUploadRequest(_fileUploader, file);
		
		// Call Dispatcher/Scheduler to enqueue it to MessageQueue
		_scheduler.Enqueue(_request);
		
		return _request.Response;
	}
	
	private ActiveScheduler _scheduler;
	private FileUploadServant _fileUploader;
	private FileUploadRequest _request;
}

// Dispatcher/Scheduler
public class ActiveScheduler
{
	public ActiveScheduler(MessageQueue queue)
	{
		this._messageQueue = queue;
	}
	
	public void Enqueue(FileUploadRequest request)
	{
		lock(_lock)
		{
			while(this._messageQueue.IsFull() == true)
			{
				Monitor.Wait(_lock);
			}
			
			this._messageQueue.Enqueue(request);
			Monitor.PulseAll(_lock);
		}
	}
	
	public void Dispatch()
	{
		lock(_lock)
		{
			while(this._messageQueue.IsEmpty() == true)
			{
				Monitor.Wait(_lock);
			}
		
			FileUploadRequest request = this._messageQueue.Peek();
		
			if(request.AllowInvoke() == true)
			{
				this._messageQueue.Dequeue();
				request.Invoke();
			}
			
			Monitor.PulseAll(_lock);
		}
	}
	
	private MessageQueue _messageQueue;
	private readonly object _lock = new object();
}


// Define other methods and classes here
