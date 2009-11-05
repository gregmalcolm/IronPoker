using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using IronPoker;

namespace IronPoker.Tests
{
    [TestFixture]
    public class CardTests
    {
        Card _card;

        [SetUp]
        public void SetUp()
        {
            _card = new Card();
        }

        [Test]
        public void Should_initially_be_invalid()
        {
            Assert.IsFalse(_card.IsValid());
        }

        [Test]
        public void Should_be_valid_if_value_is_4_and_suit_is_clubs()
        {
            _card.Value = CardValue.Four;
            _card.Suit = Suit.Clubs;
            Assert.IsTrue(_card.IsValid());
        }

        [Test]
        public void Should_be_invalid_if_value_is_a_king_and_suit_is_unknown()
        {
            _card.Value = CardValue.King;
            _card.Suit = Suit.Unknown;
            Assert.IsFalse(_card.IsValid());
        }

        [Test]
        public void Should_be_invalid_if_value_is_unknown_and_suit_is_diamonds()
        {
            _card.Value = CardValue.Unknown;
            _card.Suit = Suit.Diamonds;
            Assert.IsFalse(_card.IsValid());
        }

        [Test]
        public void Should_be_able_to_read_two_of_clubs()
        {
            Assert.IsTrue(_card.Read("2 Clubs"));
            Assert.AreEqual(CardValue.Two, _card.Value);
            Assert.AreEqual(Suit.Clubs, _card.Suit);
            Assert.IsTrue(_card.IsValid());
        }

        [Test]
        public void Should_be_able_to_read_jack_of_di()
        {
            Assert.IsTrue(_card.Read("j di"));
            Assert.AreEqual(CardValue.Jack, _card.Value);
            Assert.AreEqual(Suit.Diamonds, _card.Suit);
            Assert.IsTrue(_card.IsValid());
        }

        [Test]
        public void Should_be_able_to_read_eight_of_spade()
        {
            Assert.IsTrue(_card.Read("8 spade"));
            Assert.AreEqual(CardValue.Eight, _card.Value);
            Assert.AreEqual(Suit.Spades, _card.Suit);
            Assert.IsTrue(_card.IsValid());
        }

        [Test]
        public void Should_fail_to_read_hearts_suit_only()
        {
            Assert.IsFalse(_card.Read("hearts"));
            Assert.IsFalse(_card.IsValid());
        }

        [Test]
        public void Should_fail_to_read_queen_value_only()
        {
            Assert.IsFalse(_card.Read("q"));
            Assert.IsFalse(_card.IsValid());
        }

        [Test]
        public void Should_fail_to_read_junk_text()
        {
            Assert.IsFalse(_card.Read("junk text"));
            Assert.IsFalse(_card.IsValid());
        }
    }
}
