using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;


namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DecksManager Manager = new DecksManager();

            Manager.CreateCardDeck("test");
            Manager.GetDeck("test").PrintAllCards();

            Manager.GetDeck("test").Mix();
            Manager.GetDeck("test").PrintAllCards();

            Console.ReadKey(); 
        }
    }
}
