<Query Kind="Program" />

void Main()
{
	int[] stockPrices = { 12, 10, 15, 13, 12, 16, 14, 18, 11};
	
	int maxProfit = StockPriceUtil.FindMaxProfit(stockPrices);
	
	maxProfit.Dump();
}

public class StockPriceUtil
{
	public static int FindMaxProfit(int[] stockPrices)
	{
		if (stockPrices == null || stockPrices.Length == 0)
		{
			return 0;
		}
		
		List<int> maxProfits = new List<int>();
		int maxProfitSoFar = 0;
		int currentProfit = 0;
		
		for (int i = 0; i < stockPrices.Length; i++)
		{
			
		}
		
	}
}
// Define other methods and classes here
