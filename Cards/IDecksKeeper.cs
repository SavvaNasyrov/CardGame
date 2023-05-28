using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    internal interface IDecksKeeper
    {
        Exception CreateCardDeck(string name);
        Exception DeleteCardDeck(string name);
        string[] GetNames();
        bool MixDeck(string name);
        CardDeck GetDeck(string name);

    }
}
