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
  	  | 3 Clubs    | 3 Spades   | J Clubs    | 9 Diamonds | 3 Spades   | One Pair        |
