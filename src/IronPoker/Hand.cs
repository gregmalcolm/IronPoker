using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IronPoker
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }
        public bool Straight { get; private set; }
        public bool Flush { get; private set; }
        public Card[][] Groupings { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
            Straight = false;
            Flush = false;
            Groupings = new Card[][] {null};
        }

        public void AddCard(string cardVal)
        {
            var card = new Card();

            card.Read(cardVal);

            if (card.IsValid())
            {
                Cards.Add(card);
            }
        }

        public string EvalScore()
        {
            Eval();

            if (IsRoyalFlush())
            {
                return "Royal Flush";
            }

            if (Straight && Flush)
            {
                return "Straight Flush";
            }

            if (IsFourOfaKind())
            {
                return "Four of a Kind";
            }

            if (IsFullHouse())
            {
                return "Full House";
            }

            if (Flush)
            {
                return "Flush";
            }

            if (Straight)
            {
                return "Straight";
            }

            if (IsThreeOfaKind())
            {
                return "Three of a Kind";
            }

            if (IsTwoPair())
            {
                return "Two Pair";
            }

            if (IsPair())
            {
                return "One Pair";
            }

            if (IsHighCard())
            {
                return "High Card";
            }

            return "Huh? Are those monopoly cards?";
        }

        public bool Eval()
        {
            Cards = Sort();

            Straight = CalcStraight();
            Flush = CalcFlush();
            Groupings = CalcGroupings();

            return true;
        }

        private List<Card> Sort()
        {
            var sortedCards = new List<Card>();

            Card[] cards = Cards.ToArray();
            for(int i = 0 ; i < cards.Count(); i++)
            {
                bool found = false;
                for (int j = 0; !found && j < sortedCards.Count(); j++)
                {
                    if (cards[i].Value < sortedCards[j].Value)
                    {
                        sortedCards.Insert(j, cards[i]);
                        found = true;
                    }
                }
                if (!found)
                {
                    sortedCards.Add(cards[i]);
                }
            }

            return sortedCards.ToList();
        }

        private bool CalcStraight()
        {
            Card[] cards = Cards.ToArray();

            if (cards.Count() < 5)
            {
                return false;
            }

            int lastVal = (int) cards[0].Value;
            int endCard = cards.Count();
            if (Cards.Last().Value == CardValue.Ace
                && Cards[0].Value == CardValue.Two)
            {
                // Low Ace
                endCard--;
            }

            for(int i = 0; i < endCard; i++)
            {
                if ((int) cards[i].Value != lastVal)
                {
                    return false;
                }

                lastVal++;
            }

            return true;
        }
        private bool CalcFlush()
        {
            Card[] cards = Cards.ToArray();

            if (cards.Count() < 5)
            {
                return false;
            }

            Suit suit = cards[0].Suit;
            for (int i = 1; i < cards.Count(); i++)
            {
                if (cards[i].Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        private Card[][] CalcGroupings()
        {
            var groupings = new List<Card[]>();
            
            CardValue lastCard = CardValue.Unknown;
            var grouping = new List<Card>();
            foreach(Card card in Cards)
            {
                if (card.Value != lastCard)
                {
                    if (grouping.Count()>1)
                    {
                        groupings.Add(grouping.ToArray());
                    }
                    grouping = new List<Card>();
                }
                grouping.Add(card);
                lastCard = card.Value;
            }
            if (grouping.Count() > 1)
            {
                groupings.Add(grouping.ToArray());
            }

            return groupings.ToArray();
        }

        public bool IsRoyalFlush()
        {
            return (Cards.Count() >= 5 
                && (int)Cards[0].Value == (int)CardValue.Ace - (Cards.Count() - 1)
                && Flush 
                && Straight);   
        }

        public bool IsFourOfaKind()
        {
            foreach( Card[] cards in Groupings)
            {
                if (cards.Count() >= 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsThreeOfaKind()
        {
            foreach (Card[] cards in Groupings)
            {
                if (cards.Count() >= 3)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse()
        {
            bool foundThree = false;
            bool foundPair = false;
            foreach (Card[] cards in Groupings)
            {
                if (cards.Count() == 3)
                {
                    foundThree = true;
                }
            }
            foreach (Card[] cards in Groupings)
            {
                if (cards.Count() == 2)
                {
                    foundPair = true;
                }
            }

            return foundPair && foundThree;
        }

        public bool IsTwoPair()
        {
            int c = 0;
            foreach (Card[] cards in Groupings)
            {
                if (cards.Count() >= 2)
                {
                    c++;
                }
            }

            return c > 1;
        }

        public bool IsPair()
        {
            foreach (Card[] cards in Groupings)
            {
                if (cards.Count() >= 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHighCard()
        {
            return !Flush && !Straight && !IsPair();
        }
    }
}
