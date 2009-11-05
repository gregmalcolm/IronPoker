using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using IronPoker;

namespace IronPoker.Tests
{
    [TestFixture]
    public class DemoTests
    {
        Hand _hand;

        [SetUp]
        public void SetUp()
        {
            _hand = new Hand();
        }

        [Test]
        public void Should_show_one_pair_for_3c_3s_Jc_9d_As()
        {
            _hand.AddCard("3 clubs");
            _hand.AddCard("3 spades");
            _hand.AddCard("J clubs");
            _hand.AddCard("9 diamonds");
            _hand.AddCard("A spades");
            Assert.AreEqual("One Pair" , _hand.EvalScore());
        }











        [Test]
        public void Should_show_royal_flush_for_9d_Jd_Qd_Kd_Ad()
        {
            _hand.AddCard("9 diamonds");
            _hand.AddCard("J diamonds");
            _hand.AddCard("Q diamonds");
            _hand.AddCard("K diamonds");
            _hand.AddCard("A diamonds");
            Assert.AreEqual("Royal Flush", _hand.EvalScore());
        }

        [Test]
        public void Should_show_3_of_a_kind_for_8s_Jd_8d_Ks_8h()
        {
            _hand.AddCard("8 spades");
            _hand.AddCard("J diamonds");
            _hand.AddCard("8 diamonds");
            _hand.AddCard("K spades");
            _hand.AddCard("8 hearts");
            Assert.AreEqual("Three of a Kind", _hand.EvalScore());
        }

        [Test]
        public void Should_show_flush_for_9s_5s_8s_Ks_8s()
        {
            _hand.AddCard("8 spades");
            _hand.AddCard("J spades");
            _hand.AddCard("8 spades");
            _hand.AddCard("K spades");
            _hand.AddCard("8 spades");
            Assert.AreEqual("Flush", _hand.EvalScore());
        }

        [Test]
        public void Should_show_4_of_a_kind_for_2s_2d_8d_2c_2h()
        {
            _hand.AddCard("2 spades");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("8 diamonds");
            _hand.AddCard("2 clubs");
            _hand.AddCard("2 hearts");
            Assert.AreEqual("Four of a Kind", _hand.EvalScore());
        }

        [Test]
        public void Should_show_straight_for_Ah_2d_3s_4c_5s()
        {
            _hand.AddCard("A hearts");
            _hand.AddCard("2 diamonds");
            _hand.AddCard("3 spades");
            _hand.AddCard("4 clubs");
            _hand.AddCard("5 spades");
            Assert.AreEqual("Straight", _hand.EvalScore());
        }

        [Test]
        public void Should_show_full_house_for_9d_Ah_9c_As_Ah()
        {
            _hand.AddCard("9 diamonds");
            _hand.AddCard("A hearts");
            _hand.AddCard("9 clubs");
            _hand.AddCard("A spades");
            _hand.AddCard("A hearts");
            Assert.AreEqual("Full House", _hand.EvalScore());
        }

        [Test]
        public void Should_show_straight_flush_for_4d_5d_6d_7d_8d()
        {
            _hand.AddCard("4 hearts");
            _hand.AddCard("5 hearts");
            _hand.AddCard("6 hearts");
            _hand.AddCard("7 hearts");
            _hand.AddCard("8 hearts");
            Assert.AreEqual("Straight Flush", _hand.EvalScore());
        }

        [Test]
        public void Should_show_high_card_for_As_4d_5d_9c_8c()
        {
            _hand.AddCard("A spades");
            _hand.AddCard("4 diamonds");
            _hand.AddCard("5 diamonds");
            _hand.AddCard("9 clubs");
            _hand.AddCard("8 clubs");
            Assert.AreEqual("High Card", _hand.EvalScore());
        }

        [Test]
        public void Should_show_two_pairs_for_as_4d_ad_4c_8c()
        {
            _hand.AddCard("A spades");
            _hand.AddCard("4 diamonds");
            _hand.AddCard("A diamonds");
            _hand.AddCard("4 clubs");
            _hand.AddCard("8 clubs");
            Assert.AreEqual("Two Pair", _hand.EvalScore());
        }

    }
}
