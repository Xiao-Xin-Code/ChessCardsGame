using QMVC;

namespace ChessCards
{
    public class ChessCards : Architecture<ChessCards>
    {
        protected override void Init()
        {
            RegisterSystem<AssetSystem>(new AssetSystem());
            RegisterSystem<PoolSystem>(new PoolSystem());
            RegisterSystem<CardLibrarySystem>(new CardLibrarySystem());
            RegisterSystem<MatchSystem>(new MatchSystem());
            RegisterSystem<AudioSystem>(new AudioSystem());
            RegisterModel<MatchModel>(new MatchModel());
            RegisterModel<CardLibraryModel>(new CardLibraryModel());
        }
    }
}
