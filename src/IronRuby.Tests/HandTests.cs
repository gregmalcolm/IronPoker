using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using IronPoker;

namespace IronPoker.Tests
{

    [TestFixture]
    public class HandTests
    {
        Hand _hand;

        [SetUp]
        public void SetUp()
        {
            _hand = new Hand();
        }

        [Test]
        public void Should_sort_cards_during_evaluation_of_4_6_2_3_J()
        {
            _hand.AddCard("4 spades");
            _hand.AddCard("6 spades");
            _hand.AddCard("2 spades");
            _hand.AddCard("3 diamonds");
            _hand.AddCard("J spades");
            Assert.IsTrue(_hand.Eval());

            Card[] cards = _hand.Cards.ToArray();
            Assert.AreEqual(cards[0].Value, CardValue.Two);
            Assert.AreEqual(cards[1].Value, CardValue.Three);
            Assert.AreEqual(cards[2].Value, CardValue.Four);
            Assert.AreEqual(cards[3].Value, CardValue.Six);
            Assert.AreEqual(cards[4].Value, CardValue.Jack);
        }

        [Test]
        public void Should_be_straight_if_7_8_9_J_Q()
        {
            _hand.AddCard("7 spades");
            _hand.AddCard("8 spades");
            _hand.AddCard("9 spades");
            _hand.AddCard("J diamonds");
            _hand.AddCard("Q spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.Straight);
        }

        [Test]
        public void Should_be_straight_if_A_2_3_4_5()
        {
            _hand.AddCard("A clubs");
            _hand.AddCard("2 clubs");
            _hand.AddCard("3 spades");
            _hand.AddCard("4 diamonds");
            _hand.AddCard("5 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.Straight);
        }

        [Test]
        public void Should_be_straight_if_9_J_Q_K_A()
        {
            _hand.AddCard("9 clubs");
            _hand.AddCard("J clubs");
            _hand.AddCard("Q spades");
            _hand.AddCard("K diamonds");
            _hand.AddCard("A spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.Straight);
        }

        [Test]
        public void Should_not_be_straight_if_7_8_9_Q_K()
        {
            _hand.AddCard("7 spades");
            _hand.AddCard("8 spades");
            _hand.AddCard("9 spades");
            _hand.AddCard("Q diamonds");
            _hand.AddCard("K spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.Straight);
        }

        [Test]
        public void Should_not_be_straight_if_less_than_5_cards()
        {
            _hand.AddCard("7 spades");
            _hand.AddCard("8 spades");
            _hand.AddCard("9 spades");
            _hand.AddCard("J diamonds");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.Straight);
        }

        [Test]
        public void Should_be_flush_if_5_clubs()
        {
            _hand.AddCard("1 clubs");
            _hand.AddCard("8 clubs");
            _hand.AddCard("4 clubs");
            _hand.AddCard("Q clubs");
            _hand.AddCard("K clubs");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.Flush);
        }

        [Test]
        public void Should_be_flush_if_5_hearts()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("8 hearts");
            _hand.AddCard("A hearts");
            _hand.AddCard("Q hearts");
            _hand.AddCard("4 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.Flush);
        }

        [Test]
        public void Should_not_be_flush_if_4_hearts_and_1_club()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("8 hearts");
            _hand.AddCard("A hearts");
            _hand.AddCard("Q hearts");
            _hand.AddCard("4 clubs");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse (_hand.Flush);
        }

        [Test]
        public void Should_not_be_flush_if_4_hearts()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("8 hearts");
            _hand.AddCard("A hearts");
            _hand.AddCard("Q hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.Flush);
        }

        [Test]
        public void Should_be_no_groupings_with_3_5_6_7_J()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("5 clubs");
            _hand.AddCard("6 hearts");
            _hand.AddCard("7 diamonds");
            _hand.AddCard("J spades");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(0, _hand.Groupings.Length);
        }

        [Test]
        public void Should_be_1_pair_grouping_with_3_5_6_3_J()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("5 clubs");
            _hand.AddCard("6 hearts");
            _hand.AddCard("3 diamonds");
            _hand.AddCard("J spades");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(1, _hand.Groupings.Length);
            Assert.AreEqual(2, _hand.Groupings[0].Length);
            Assert.AreEqual(CardValue.Three, _hand.Groupings[0][0].Value);
        }
        [Test]
        public void Should_be_2_pairs_grouping_with_3_5_J_J_3()
        {
            _hand.AddCard("3 hearts");
            _hand.AddCard("5 clubs");
            _hand.AddCard("J hearts");
            _hand.AddCard("J diamonds");
            _hand.AddCard("3 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(2, _hand.Groupings.Length);
            Assert.AreEqual(2, _hand.Groupings[0].Length);
            Assert.AreEqual(CardValue.Three, _hand.Groupings[0][0].Value);

            Assert.AreEqual(2, _hand.Groupings[1].Length);
            Assert.AreEqual(CardValue.Jack, _hand.Groupings[1][0].Value);
        }

        [Test]
        public void Should_be_3_of_a_kind_grouping_with_4_4_8_J_4()
        {
            _hand.AddCard("4 hearts");
            _hand.AddCard("4 clubs");
            _hand.AddCard("8 hearts");
            _hand.AddCard("J diamonds");
            _hand.AddCard("4 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(1, _hand.Groupings.Length);
            Assert.AreEqual(3, _hand.Groupings[0].Length);
            Assert.AreEqual(CardValue.Four, _hand.Groupings[0][0].Value);
        }

        [Test]
        public void Should_be_full_house_grouping_with_Q_5_Q_Q_5()
        {
            _hand.AddCard("Q hearts");
            _hand.AddCard("5 clubs");
            _hand.AddCard("Q spades");
            _hand.AddCard("Q diamonds");
            _hand.AddCard("5 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(2, _hand.Groupings.Length);
            Assert.AreEqual(2, _hand.Groupings[0].Length);
            Assert.AreEqual(CardValue.Five, _hand.Groupings[0][0].Value);

            Assert.AreEqual(3, _hand.Groupings[1].Length);
            Assert.AreEqual(CardValue.Queen, _hand.Groupings[1][0].Value);
        }

        [Test]
        public void Should_be_four_of_a_kind_with_9_5_9_9_9()
        {
            _hand.AddCard("9 hearts");
            _hand.AddCard("5 clubs");
            _hand.AddCard("9 spades");
            _hand.AddCard("9 diamonds");
            _hand.AddCard("9 clubs");
            Assert.IsTrue(_hand.Eval());

            Assert.AreEqual(1, _hand.Groupings.Length);
            Assert.AreEqual(4, _hand.Groupings[0].Length);
            Assert.AreEqual(CardValue.Nine, _hand.Groupings[0][0].Value);
        }

        [Test]
        public void Should_be_RoyalFlush_if_Qs_Ks_Js_9s_As()
        {
            _hand.AddCard("Q spades");
            _hand.AddCard("K spades");
            _hand.AddCard("J spades");
            _hand.AddCard("9 spades");
            _hand.AddCard("A spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsRoyalFlush());
        }

        [Test]
        public void Should_not_be_RoyalFlush_if_Qs_Ks_Js_8s_As()
        {
            _hand.AddCard("Q spades");
            _hand.AddCard("K spades");
            _hand.AddCard("J spades");
            _hand.AddCard("8 spades");
            _hand.AddCard("A spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsRoyalFlush());
        }

        [Test]
        public void Should_be_Four_of_Kind_if_9_9_9_9_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 hearts");
            _hand.AddCard("9 clubs");
            _hand.AddCard("9 diamond");
            _hand.AddCard("8 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsFourOfaKind());
        }

        [Test]
        public void Should_not_be_Four_of_Kind_if_9_9_7_9_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 hearts");
            _hand.AddCard("7 spades");
            _hand.AddCard("9 diamond");
            _hand.AddCard("8 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsFourOfaKind());
        }

        [Test]
        public void Should_be_Three_of_Kind_if_9_9_7_9_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 hearts");
            _hand.AddCard("7 spades");
            _hand.AddCard("9 diamond");
            _hand.AddCard("8 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsThreeOfaKind());
        }

        [Test]
        public void Should_not_be_Three_of_Kind_if_9_7_7_9_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("7 spades");
            _hand.AddCard("7 hearts");
            _hand.AddCard("9 diamond");
            _hand.AddCard("8 spades");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsThreeOfaKind());
        }

        [Test]
        public void Should_be_Full_House_if_9_9_7_9_7()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 hearts");
            _hand.AddCard("7 spades");
            _hand.AddCard("9 diamonds");
            _hand.AddCard("7 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsFullHouse());
        }

        [Test]
        public void Should_not_be_Full_House_if_9_7_7_2_7()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("7 hearts");
            _hand.AddCard("7 spades");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("7 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsFullHouse());
        }

        [Test]
        public void Should_be_Two_Pair_if_9_9_7_9_7()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 hearts");
            _hand.AddCard("7 spades");
            _hand.AddCard("9 diamonds");
            _hand.AddCard("7 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsTwoPair());
        }

        [Test]
        public void Should_not_be_Two_Pair_if_9_7_7_2_7()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("7 hearts");
            _hand.AddCard("7 clubs");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("7 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsTwoPair());
        }

        [Test]
        public void Should_be_Pair_if_9_9_7_9_7()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("9 clubs");
            _hand.AddCard("7 spades");
            _hand.AddCard("9 diamonds");
            _hand.AddCard("7 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsPair());
        }

        [Test]
        public void Should_not_be_Pair_if_9_7_3_2_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("7 spades");
            _hand.AddCard("3 spades");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("8 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsPair());
        }

        [Test]
        public void Should_be_High_Card_if_4_9_7_6_K()
        {
            _hand.AddCard("4 spades");
            _hand.AddCard("9 spades");
            _hand.AddCard("7 spades");
            _hand.AddCard("6 diamonds");
            _hand.AddCard("K hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsTrue(_hand.IsHighCard());
        }

        [Test]
        public void Should_not_be_High_Card_if_9_3_3_2_8()
        {
            _hand.AddCard("9 spades");
            _hand.AddCard("3 spades");
            _hand.AddCard("3 hearts");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("8 hearts");
            Assert.IsTrue(_hand.Eval());

            Assert.IsFalse(_hand.IsHighCard());
        }
    }
}
