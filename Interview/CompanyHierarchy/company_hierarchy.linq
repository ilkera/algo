<Query Kind="Program" />

void Main()
{
	string[] employeeWithManagers = File.ReadAllLines(@"C:\GitHub\algo\Interview\CompanyHierarchy\input.txt");
	Organization org = new Organization();
	
	foreach (var line in employeeWithManagers)
	{
		string employee = line.Split(' ')[0];
		string manager = line.Split(' ')[1];
		org.AddEmployee(employee, manager);
	}
	
	org.PrintOrganization();
}

public class Organization
{
	private Dictionary<string, List<string>> _employeeManagerMap;
	private string _topManager;
	
	public Organization()
	{
		this._employeeManagerMap = new Dictionary<string, List<string>>();
	}
	
	public void AddEmployee(string employee, string manager)
	{
		if (string.IsNullOrEmpty(manager) == true)
		{
			this._topManager = employee;
		}
		
		if (this._employeeManagerMap.ContainsKey(manager) == false)
		{
			this._employeeManagerMap.Add(manager, new List<string>());
		}
		this._employeeManagerMap[manager].Add(employee);
	}
	
	public void PrintOrganization()
	{	
		Queue<string> employees = new Queue<string>();
		employees.Enqueue(this._topManager);
		
		int currentLevelCount = 1;
		int nextLevelCount = 0;
		
		while (employees.Count != 0)
		{
			string current = employees.Dequeue();
			Console.Write(current + "\t");
			currentLevelCount--;
			
			if (this._employeeManagerMap.ContainsKey(current) == true)
			{
				foreach (var report in this._employeeManagerMap[current])
				{
					employees.Enqueue(report);
					nextLevelCount++;
				}
			}
			
			if (currentLevelCount == 0)
			{
				currentLevelCount = nextLevelCount;
				nextLevelCount = 0;
				Console.WriteLine("");
			}
		}
	}
}

// Define other methods and classes here