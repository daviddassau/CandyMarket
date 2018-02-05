using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMarket
{
    class CandyBag
    {
        public User Owner { get; set; }

        public Dictionary<CandyType, int> Bag { get; set; } = new Dictionary<CandyType, int>();
    }
}
