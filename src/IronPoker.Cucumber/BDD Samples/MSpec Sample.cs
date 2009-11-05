// machine.spec (mspec) sample

using IronPoker;

[Description]
public class Player_showing_their_hand
{
    static Hand _hand;

    Context before_each = () =>
    {
        _hand = new _Hand();
    };

    When 3_clubs_and_3_spades_and_J_clubs_and_9_clubs_and_A_Spades_are_dealt = () =>
    {
        _hand.AddCard("3 clubs");
        _hand.AddCard("3 spades");
        _hand.AddCard("J clubs");
        _hand.AddCard("9 diamonds");
        _hand.AddCard("A spades");

        _result = _hand.EvalScore();
    };

    It should_show_a_score_of_One_Pair = () =>
    {
        _result.ShouldEqual("One Pair");
    };
}