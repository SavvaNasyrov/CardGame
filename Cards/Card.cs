using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    internal class Card
    {
        string name;
        public string Name { get => name; }

        public Card(string name) => this.name = name;
        public Card() { }
    }
}
