using System;
using System.Collections.Generic;

namespace CoinJarInterview
{
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
}