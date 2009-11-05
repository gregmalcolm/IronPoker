using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IronPoker
{
    public enum CardValue
    {
        Unknown,

        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King,
        Ace
    } 

    public enum Suit
    {
        Unknown,

        Spades,
        Diamonds,
        Clubs,
        Hearts
    }

    public class Card
    {
        public CardValue Value { get; set; }
        public Suit Suit { get; set; }

        public Card()
        {
            Reset();
        }

        private void Reset()
        {
            Value = CardValue.Unknown;
            Suit = Suit.Unknown;
        }

        public bool Read(string val)
        {
            Reset();

            val = val.ToLower();
            if (val.Length<4)
            {
                return false;
            }

            if (!(new Regex(@"^[\djqka] \w\w").IsMatch(val)))
            {
                return false;
            }

            Value = ReadValue(val);
            Suit = ReadSuite(val);
            return IsValid();
        }

        private CardValue ReadValue(string val)
        {
            CardValue cardValue = CardValue.Unknown;

            string c = val[0].ToString().ToLower();
            int numVal = 0;
            if (int.TryParse(c, out numVal))
            {
                cardValue = (CardValue)numVal;
            }
            else
            {
                switch(c)
                {
                    case "j":
                        cardValue = CardValue.Jack;
                        break;

                    case "q":
                        cardValue = CardValue.Queen;
                        break;

                    case "k":
                        cardValue = CardValue.King;
                        break;

                    case "a":
                        cardValue = CardValue.Ace;
                        break;
                }
            }

            return cardValue;
        }

        private Suit ReadSuite(string val)
        {
            Suit suit = Suit.Unknown;

            string s = val.Substring(2,2).ToLower();

            switch (s)
            {
                case "cl":
                    suit = Suit.Clubs;
                    break;

                case "he":
                    suit = Suit.Hearts;
                    break;

                case "sp":
                    suit = Suit.Spades;
                    break;

                case "di":
                    suit = Suit.Diamonds;
                    break;
            }

            return suit;
        }

        public bool IsValid()
        {
            return CardValue.Unknown != Value && Suit != Suit.Unknown;
        }
    }
}
