using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace Cards
{
    internal class CardDeck
    {
        string mixMode;
        private Card[] cards = new Card[52];

        private bool SetDefaultCards()
        {
            var Reader = XmlReader.Create("DefaultCards.xml");
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();
            Reader.Read();

            for (int i = 0; i < 52; i++)
            {
                cards[Convert.ToInt32(Reader.GetAttribute("key"))] = new Card(Reader.GetAttribute("value"));
                Reader.Read();
                Reader.Read();
            }

            return true;
        }

        public CardDeck()
        {
            SetDefaultCards();
            mixMode = ConfigurationManager.AppSettings["mixingmode"];
        }

        public void PrintAllCards()
        {
            for (int i = 0;i < cards.Length;i++) 
            {
                Console.WriteLine($"{i} - {cards[i].Name}");
            }
        }

        public void Mix()
        {
            if (mixMode == "hand")
                HandMix();
            else
                SimpleMix();
            
        }

        private void HandMix()
        {
            Random random = new Random();
            for (int j = 0; j < 100; j++)
            {
                int starts = random.Next(cards.Length/2 - cards.Length/5, cards.Length/2 + cards.Length/5);

                Card[] first = new Card[starts];
                Card[] second = new Card[cards.Length - starts];

                int counter = 0;

                for (int i = 0; i < starts; i++)
                {
                    first[i] = cards[i];
                    counter = i;
                }

                counter++;

                for (int i = 0; i < second.Length; i++, counter++)
                {
                    second[i] = cards[counter];
                }

                counter = 0;

                for (int i = 0; i < second.Length; i++)
                {
                    cards[i] = second[i];
                    counter = i;
                }

                for (int i = 0; i < first.Length; i++, counter++)
                {
                    cards[counter] = first[i];
                }
            }
        }

        private void SimpleMix()
        {
            Random rand = new Random();
            for (int i = cards.Length - 1; i >= 1; i--)
            {
                int j = rand.Next() % (i + 1);

                Card tmp = cards[j];
                cards[j] = cards[i];
                cards[i] = tmp;
            }
        }
    }
}
