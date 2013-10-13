<Query Kind="Program" />

void Main()
{
	ArrayList list = new ArrayList();
	list.Add(1);
	list.Add(new ArrayList() { 2, 3 });
	
	ArrayList inner = new ArrayList();
	inner.Add(4);
	ArrayList inner2 = new ArrayList() { 5, 6};
	inner.Add(inner2);
	inner.Add(7);
	
	list.Add(inner);
	
	var output = new ArrayList();
	Flatten(list, ref output);
	
	foreach (var item in output)
	{
		Console.Write("{0} ", item);
	}
	
	Console.WriteLine("");
}

private ArrayList Flatten(ArrayList list, ref ArrayList outList)
{
	foreach (var item in list)
	{
		if (item is ArrayList)
		{
			outList = Flatten((ArrayList)item, ref outList);
		}
		else
		{	
			outList.Add(item);
		}
	}	
	
	return outList;
}
// Define other methods and classes here
