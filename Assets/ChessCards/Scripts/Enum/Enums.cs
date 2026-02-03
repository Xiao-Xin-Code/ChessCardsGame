
public enum Suit
{
    None,
    Spade,
    Heart,
    Diamond,
    Club
}


public enum Rank
{
    None,
    Rank3,Rank4,Rank5,Rank6,Rank7,Rank8,Rank9,Rank10,RankJ,RankQ,RankK,RankA,Rank2,
    JokerSmall,JokerBig
}



public enum GameState
{
	Init,
	Prepare, 
    DealCard,   
    CallScore,  
    DealBaseCard, 
    PlayCard,   
    GameOver     
}


public enum PlayerRole
{
    None,
    Landlord,   
    Farmer      
}