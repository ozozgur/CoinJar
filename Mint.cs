using System;
using System.Collections.Generic;

namespace CoinJarInterview
{
    public abstract class Mint
    {
        public abstract Coin ManufactureCoinOfValue(int value);
    }
}