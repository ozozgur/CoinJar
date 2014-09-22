using System;
using System.Collections.Generic;
namespace CoinJarInterview
{
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
}