using System;
using System.Collections.Generic;

public class Coin
{
    private int value;
	
    public int Value { get { return this.value; } }
	
	private float volume;
	
	public float Volume { get { return this.volume; } }
	
	public Coin(int value, float volume)
	{
		this.value = value;
		this.volume = volume;
	}
}

public class CoinJar
{
	private List<Coin> Coins { get; set; }

	private float totalVolume = 32;
	
	public float TotalVolume { get { return this.totalVolume; } }
	
	private float usedVolume = 0f;
	
	public float UsedVolume { get { return this.usedVolume; } }
	
	// stored in cents
	private int totalValue = 0;
	
	// returned in dollars
	public float TotalValue { get { return this.totalValue / 100.0f; } }
	
	public CoinJar()
	{
		this.Coins = new List<Coin>();
	}
	
	public bool AddCoin(Coin coin)
	{
		if (coin == null)
		{
			return false;
		}
		
		if (coin.Volume + this.UsedVolume > this.TotalVolume)
		{
			return false;
		}
		
		this.Coins.Add(coin);
		this.totalValue += coin.Value;
		this.usedVolume += coin.Volume;

		return true;
	}
	
	public List<Coin> Empty()
	{
		List<Coin> coins = this.Coins;
		this.Coins = new List<Coin>();
		this.totalValue = 0;
		this.usedVolume = 0f;
		return coins;
	}
}

public abstract class Mint
{
	public abstract Coin ManufactureCoinOfValue(int value);
}

public class AmericanMint : Mint
{
	private static List<Coin> CoinTypes { get; set; }
	
	static AmericanMint()
	{
		CoinTypes = new List<Coin>();
		CoinTypes.Add(new Coin(1, 0.0122f));
		CoinTypes.Add(new Coin(5, 0.0243f));
		CoinTypes.Add(new Coin(10, 0.0115f));
		CoinTypes.Add(new Coin(25, 0.027f));
	}
	
	public override Coin ManufactureCoinOfValue(int value)
	{
		Coin modelCoin = null;
		
		foreach (Coin coin in CoinTypes)
		{
			if (coin.Value == value)
			{
				modelCoin = coin;
				break;
			}
		}
		
		if (modelCoin != null)
		{
			return new Coin(modelCoin.Value, modelCoin.Volume);
		}
		else
		{
			return null;
		}
	}
}

public class Program
{
	public static void Main()
	{
		AmericanMint mint = new AmericanMint();
		CoinJar jar = new CoinJar();
		Coin newCoin = null;

		Console.WriteLine("Total Value: " + jar.TotalValue);
		Console.WriteLine("Used Volume: " + jar.UsedVolume);

		newCoin = mint.ManufactureCoinOfValue(25);
		
		Console.WriteLine("Coin successfully created: " + (newCoin != null));
		
		newCoin = mint.ManufactureCoinOfValue(30);
		
		Console.WriteLine("Coin successfully created: " + (newCoin != null));
		
		jar.AddCoin(mint.ManufactureCoinOfValue(1));
		jar.AddCoin(mint.ManufactureCoinOfValue(1));
		jar.AddCoin(mint.ManufactureCoinOfValue(5));
		jar.AddCoin(mint.ManufactureCoinOfValue(10));
		jar.AddCoin(mint.ManufactureCoinOfValue(10));
		jar.AddCoin(mint.ManufactureCoinOfValue(25));
		jar.AddCoin(mint.ManufactureCoinOfValue(25));
		jar.AddCoin(mint.ManufactureCoinOfValue(25));
		
		Console.WriteLine("Total Value: " + jar.TotalValue);
		Console.WriteLine("Used Volume: " + jar.UsedVolume);
		
		List<Coin> myCoins = jar.Empty();
		
		Console.WriteLine("Total Value: " + jar.TotalValue);
		Console.WriteLine("Used Volume: " + jar.UsedVolume);
		
		foreach (Coin coin in myCoins)
		{
			jar.AddCoin(coin);
			Console.WriteLine("Re add coin: " + coin.Value);
		}

		Console.WriteLine("Total Value: " + jar.TotalValue);
		Console.WriteLine("Used Volume: " + jar.UsedVolume);
	}
}
