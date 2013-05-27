<Query Kind="Program" />

/* Problem: Best time to buy and sell stock

Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction 
(ie, buy one and sell one share of the stock), 

Design an algorithm to find the maximum profit.

*/
void Main()
{
	int[] stockPrices = { 12, 10, 15, 13, 12, 16, 14, 18, 11};
	
	int buyDay = 0;
	int sellDay = 0;
	int maxProfit = StockPriceUtil.FindMaxProfit(stockPrices, ref buyDay, ref sellDay);
	
	Console.WriteLine("Max profit: {0} Buy: {1} Sell: {2}", maxProfit, buyDay, sellDay);
}

public class StockPriceUtil
{
	public static int FindMaxProfit(int[] stockPrices, ref int buyDay, ref int sellDay)
	{
		if (stockPrices == null || stockPrices.Length == 0)
		{
			return 0;
		}
		
		int maxProfit = 0;
		int minStockIndex = 0;
		
		for (int i = 0; i < stockPrices.Length; i++)
		{
			if(stockPrices[i] < stockPrices[minStockIndex])
			{
				minStockIndex = i;
			}
			
			int currentProfit = stockPrices[i] - stockPrices[minStockIndex];
			if(maxProfit < currentProfit )
			{
				maxProfit = currentProfit;
				buyDay = minStockIndex;
				sellDay = i;
			}
		}
		return maxProfit;
	}
}

// Define other methods and classes here
