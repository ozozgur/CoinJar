using System;
using System.Collections.Generic;
namespace CoinJarInterview
{
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
}