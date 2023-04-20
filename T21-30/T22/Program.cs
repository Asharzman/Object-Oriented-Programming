using System;
using System.Collections.Generic;

namespace Card_Deck
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return Value + " of " + Suit;
        }
    }

    public class CardDeck
    {
        private List<Card> _cards;

        public CardDeck()
        {
            _cards = new List<Card>();
            string[] suits = { "Heart", "Square", "Cross", "Spade" };
            string[] values = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    _cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card card = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = card;
            }
        }

        public void PrintDeck()
        {
            foreach (Card card in _cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" _____               _     \r\n/  __ \\             | |    \r\n| /  \\/ __ _ _ __ __| |___ \r\n| |    / _` | '__/ _` / __|\r\n| \\__/\\ (_| | | | (_| \\__ \\\r\n \\____/\\__,_|_|  \\__,_|___/\r\n                           ");
            CardDeck deck = new CardDeck();
            Console.WriteLine("Unshuffled deck:");
            deck.PrintDeck();

            Console.WriteLine("\nShuffled deck:");
            deck.Shuffle();
            deck.PrintDeck();
            Console.WriteLine("");
            Console.WriteLine("\nPress any key to exit the program.");
            Console.ReadKey();
        }
    }
}