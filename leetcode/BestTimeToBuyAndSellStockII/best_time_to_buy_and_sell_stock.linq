<Query Kind="Program" />

/* Problem: Best time to buy and sell stock 2

Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit.

You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times).
However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).

*/
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
		
		int maxProfit = 0;
		
		for (int i = 1; i < stockPrices.Length; i++)
		{
			if(stockPrices[i] > stockPrices[i-1])
			{
				maxProfit += stockPrices[i] - stockPrices[i-1];
			}
		}
		
		return maxProfit;
	}
}

// Define other methods and classes here
