require 'spec/expectations'
$:.unshift(File.dirname(__FILE__) + '/../../../IronPoker/bin/Debug/')

require 'IronPoker' # IronPoker.dll

Before do
  @hand = IronPoker::Hand.new 
end

Given /^I have a (.*) in my hand$/ do |c|
  # c = (.*)

  @hand.add_card c
end

When /I am dealt a card/ do
  @result = @hand.eval_score
end

Then /the result should be (.*) on the screen/ do |score|
  @result.should == score
end
