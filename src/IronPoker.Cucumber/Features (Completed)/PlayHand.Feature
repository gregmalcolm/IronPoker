Feature: Player shows their hand
  In order to finish the round
  The player
  Needs to show their hand

  Scenario Outline: Play is dealt a card
      Given I have a <card_1> in my hand
      And I have a <card_2> in my hand
      And I have a <card_3> in my hand
      And I have a <card_4> in my hand
      And I have a <card_5> in my hand
      When I am dealt a card
      Then the result should be <output> on the screen

    Examples:
      |   card_1   |   card_2   |   card_3   |   card_4   |   card_5   |      output     |
  	  | 3 Clubs    | 3 Spades   | J Clubs    | 9 Diamonds | A Spades   | One Pair        |
      | 9 Diamonds | J Diamonds | Q Diamonds | K Diamonds | A Diamonds | Royal Flush     |
      | 8 Spades   | J Diamonds | 8 Diamonds | K Spades   | 8 Hearts   | Three of a Kind |
      | 8 Spades   | J Spades   | 8 Spades   | K Spades   | 8 Spades   | Flush           |
      | 2 Spades   | 2 Diamonds | 8 Diamonds | 2 Clubs    | 2 Hearts   | Four of a Kind  |
      | A Hearts   | 2 Diamonds | 3 Spades   | 4 Clubs    | 5 Spades   | Straight        |
      | 9 Diamonds | A Hearts   | 9 Clubs    | A Spades   | A Hearts   | Full House      |
      | 4 Hearts   | 5 Hearts   | 6 Hearts   | 7 Hearts   | 8 Hearts   | Straight Flush  |
      | A Spades   | 4 Diamonds | 5 Diamonds | 9 Diamonds | 8 Diamonds | High Card       |
      | A Spades   | 4 Diamonds | A Diamonds | 4 Clubs    | 8 Clubs    | Two Pair        |
