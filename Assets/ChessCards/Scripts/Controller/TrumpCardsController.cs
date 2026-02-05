using QMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChessCards
{
    public class TrumpCardsController : MonoController
    {
        [SerializeField] TrumpCardsView _view;
        TrumpCardsEntity _entity;
        CardLibrarySystem _cardLibrarySystem;
        AssetSystem _assetSystem;

        public override void Init()
        {
            _cardLibrarySystem = this.GetSystem<CardLibrarySystem>();
            _assetSystem = this.GetSystem<AssetSystem>();

            this.RegisterEvent<SetTrumpCardsEvent>(SetTrumpCards);
        }



        


        private void SetTrumpCards(SetTrumpCardsEvent evt)
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (var item in _cardLibrarySystem.TrumpCards) 
            {
                if(_cardLibrarySystem.TryGetCardEntity(item, out CardEntity cardEntity))
                {
                    if (_assetSystem.TryGetRankIcon($"{cardEntity.suit}_{cardEntity.rank}", out Sprite sprite))
                    {
                        sprites.Add(sprite);
                    }
                }
            }
            _view.SetTrumpCards(sprites);
        }

    }
}


