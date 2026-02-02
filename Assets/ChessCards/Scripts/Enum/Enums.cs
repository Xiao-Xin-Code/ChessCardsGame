//牌的花色
public enum Suit
{
    None,
    Spade,
    Heart,
    Diamond,
    Club
}

//牌的点数
public enum Rank
{
    None,
    Rank3,Rank4,Rank5,Rank6,Rank7,Rank8,Rank9,Rank10,RankJ,RankQ,RankK,RankA,Rank2,
    JokerSmall,JokerBig
}


// 游戏状态
public enum GameState
{
    Init,       // 初始化
    DealCard,   // 发牌中
    CallScore,  // 叫分中
    DealBaseCard,// 发底牌
    PlayCard,   // 出牌中
    GameOver    // 游戏结束
}

// 玩家类型
public enum PlayerType
{
    None,
    Landlord,   // 地主
    Farmer      // 农民
}