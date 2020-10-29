Feature: Paying Out
	In order to make money
	As a Customer
	I should have winnings added to my pot when I win a game

Scenario: Player gets Blackjack and beats Dealer
	Given that I have logged in with an account with the following details
	  | Email					 | Name		| Password	|
	  | Scott@elbandit.co.uk	 | Scott    | Cheese@123|	
	And I have started a new game and bet "10"
	And I have "10" dollars in my pot
	And the deck contains the following cards:
	  | Suit	 | Value	|
	  | Diamonds | Ace	    |
	  | Diamonds | Eight    |
	  | Clubs	 | Ten		|    
	  | Hearts	 | Two		|      	  	  
	And I have navigated to the game play screen to play a hand	
	When I click on the deal button
	Then my pot should show "$35.00" dollars

Scenario: Both player and dealer get blackjack so game ends in draw
	Given that I have logged in with an account with the following details
	  | Email					 | Name		| Password	|
	  | Scott@elbandit.co.uk	 | Scott    | Cheese@123|	
	And I have started a new game and bet "5"
	And I have "10" dollars in my pot
	And the deck contains the following cards:
	  | Suit	| Value	|  
	  | Hearts	| Ace	|
	  | Spades	| Ten	|
	  | Hearts	| Ten	|	  	  	  
	  | Clubs	| Ace	|          
	And I have navigated to the game play screen to play a hand	
	When I click on the deal button	    
	Then my pot should show "$15.00" dollars

Scenario: Player loses
	Given that I have logged in with an account with the following details
	  | Email					 | Name		| Password	|
	  | Scott@elbandit.co.uk	 | Scott    | Cheese@123|	
	And I have started a new game and bet "5"
	And I have "10" dollars in my pot
	And the deck contains the following cards:
	  | Suit	 | Value	|
	  | Diamonds | Eight    |
	  | Diamonds | Ace	    |
	  | Hearts	 | Two		|
	  | Clubs	 | Ten		|         
	And I have navigated to the game play screen to play a hand	
	When I click on the deal button	    
	Then my pot should show "$10.00" dollars

Scenario: Player loses but has taken insurance
	Given that I have logged in with an account with the following details
	  | Email					 | Name		| Password	|
	  | Scott@elbandit.co.uk	 | Scott    | Cheese@123|	
	And I have started a new game and bet "5"
	And I have "10" dollars in my pot	
	And the deck contains the following cards:
	  | Suit	 | Value	|
	  | Diamonds | Eight    |
	  | Diamonds | Ace	    |
	  | Hearts	 | Ten		|
	  | Clubs	 | Ten		|   	      
	And I have navigated to the game play screen to play a hand	
	And I have "10" dollars in my pot
	When I click on the deal button	   
	When I click on take insurance
	When I stick 
	Then my pot should show "$15.00" dollars

Scenario: Double Down and win
	Given that I have logged in with an account with the following details
	  | Email					 | Name		| Password	|
	  | Scott@elbandit.co.uk	 | Scott    | Cheese@123|	
	And I have started a new game and bet "10"	
	And I have "30" dollars in my pot
	And the deck contains the following cards:
	  | Suit	 | Value	|
	  | Diamonds | Eight    |
	  | Hearts	 | Ten		|  
	  | Clubs	 | Two		|
	  | Hearts	 | Three	|  	 
	  | Hearts	 | Two		|  	 
	  | Hearts	 | Jack		| 
	  | Hearts	 | King		| 
	And I have navigated to the game play screen to play a hand	
	When I click on the deal button	
	When I click on the double button	
	Then my pot should show "$70.00" dollars