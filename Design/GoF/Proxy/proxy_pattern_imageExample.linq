<Query Kind="Program" />

/* Proxy Pattern example

Responsibility = cache

*/

void Main()
{
	ProxyImage image1 = new ProxyImage("A101.jpeg");	
	ProxyImage image2 = new ProxyImage("B202.jpeg");
		
	image1.DisplayImage();
	image1.DisplayImage();
	
	Console.WriteLine("----");
	
	image2.DisplayImage();
	image2.DisplayImage();
}

// Subject
public interface Image
{
	void DisplayImage();
}

// Real Subject
public class RealImage : Image
{
	private string _fileName;
	
	public RealImage(string fileName)
	{
		this._fileName = fileName;
		this.LoadImageFromDisk();
	}
	
	public void DisplayImage()
	{
		Console.WriteLine("Displaying {0}", this._fileName);
	}
	
	private void LoadImageFromDisk()
	{
		Console.WriteLine("Loading image {0} from disk.", this._fileName);
	}
}

// Proxy class
public class ProxyImage : Image
{
	private RealImage _image;
	private string _fileName;
	
	public ProxyImage(string fileName)
	{
		this._fileName = fileName;
	}
	
	public void DisplayImage()
	{	
		if(_image == null)
		{
			_image = new RealImage(this._fileName);
		}
		_image.DisplayImage();
	}
}

// Define other methods and classes here
