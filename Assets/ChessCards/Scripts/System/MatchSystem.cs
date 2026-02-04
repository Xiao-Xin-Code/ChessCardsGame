using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class MatchSystem : AbstractSystem
    {
        MatchModel _matchModel;


        protected override void OnInit()
        {
            _matchModel = this.GetModel<MatchModel>();
        }

        #region Player

        public bool TryGetLocalEntity(out PlayerEntity localEntity)
        {
			return _matchModel.playerEntitys.TryGetValue(_matchModel.localHome, out localEntity);
		}

        public bool TryGetPlayerEntity(int entityId,out PlayerEntity entity)
        {
            return _matchModel.playerEntitys.TryGetValue(entityId, out entity);
        }

        public void AddPlayerEntity(int entityId, PlayerEntity entity)
        {
            _matchModel.playerEntitys.Add(entityId, entity);
            Debug.Log("Ìí¼Ó" + entityId);
            _matchModel.players.Add(entityId);
        }

        #endregion
    }
}


