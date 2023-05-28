using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    internal class DecksManager : IDecksKeeper
    {
        Dictionary<string, CardDeck> decks = new Dictionary<string, CardDeck>();
        public Exception CreateCardDeck(string name)
        {
            try
            {
                decks.Add(name, new CardDeck());
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }

        public Exception DeleteCardDeck(string name)
        {
            try
            {
                decks.Remove(name);
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }

        public CardDeck GetDeck(string name)
        {
            return decks[name];
        }

        public string[] GetNames()
        {
            return decks.Keys.ToArray(); 
        }

        public bool MixDeck(string name)
        {
            throw new NotImplementedException();
        }
    }
}
