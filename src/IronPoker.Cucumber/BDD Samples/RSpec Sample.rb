# hand_spec.rb

require 'IronPoker'

describe Hand do
  it "show a score of 'One Pair' if player has " +
  "3 Clubs, 3 Spades, J Clubs, 9 Diamonds and A Spades" do
    20.times { bowling.hit(0) }
    bowling.score.should == 0
    
    hand = IronPoker::Hand.new
    hand.add_card "3 Clubs" 
    hand.add_card "3 Spades"
    hand.add_card "J Clubs"
    hand.add_card "9 Diamonds"
    hand.add_card "A Spades"
    
    score = hand.eval_score
    score.should = "One Pair"   
  end
end

-----------------------------------------------------------
$ spec hand_spec.rb --format specdoc

Hand
- show a score of 'One Pair' if player has 3 Clubs, 3 Spades, J Clubs, 9 Diamonds and
  A Spades

Finished in 0.007534 seconds

1 example, 0 failures