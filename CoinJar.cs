using System;
using System.Collections.Generic;

public class Coin
{
	public Type Mint { get; private set; }
	
	public int Value { get; private set; }
	
	public float Volume { get; private set; }
	
	public Coin(Type mint, int value, float volume)
	{
		this.Mint = mint;
		this.Value = value;
		this.Volume = volume;
	}
}

public class CoinJar
{
	private List<Coin> Coins { get; set; }
	
	public float TotalVolume { get; private set; }
	
	public float UsedVolume { get; private set; }
	
	// returned in dollars
	public float TotalValue { get; private set; }
	
	public CoinJar()
	{
		this.Coins = new List<Coin>();
		this.TotalValue = 0;
		this.TotalVolume = 32f;
		this.UsedVolume = 0f;
	}
	
	public bool AddCoin(Coin coin)
	{
		if (coin == null || coin.Mint != typeof(AmericanMint))
		{
			return false;
		}
		
		if (coin.Volume + this.UsedVolume > this.TotalVolume)
		{
			return false;
		}
		
		this.Coins.Add(coin);
		this.TotalValue += coin.Value;
		this.UsedVolume += coin.Volume;

		return true;
	}
	
	public List<Coin> Empty()
	{
		List<Coin> coins = this.Coins;
		this.Coins = new List<Coin>();
		this.TotalValue = 0;
		this.UsedVolume = 0f;
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
		Type mintType = typeof(AmericanMint);
		CoinTypes = new List<Coin>();
		CoinTypes.Add(new Coin(mintType, 1, 0.0122f));
		CoinTypes.Add(new Coin(mintType, 5, 0.0243f));
		CoinTypes.Add(new Coin(mintType, 10, 0.0115f));
		CoinTypes.Add(new Coin(mintType, 25, 0.027f));
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
			return new Coin(modelCoin.Mint, modelCoin.Value, modelCoin.Volume);
		}
		else
		{
			return null;
		}
	}
}
