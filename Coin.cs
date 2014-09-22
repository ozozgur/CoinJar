using System;
using System.Collections.Generic;
namespace CoinJarInterview
{
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
}