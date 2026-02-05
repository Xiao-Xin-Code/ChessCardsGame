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

        public void SetLocalHome(int localId)
        {
            _matchModel.localHome = localId;
        }

        public void SetCurrentHome(int currentId)
        {
            _matchModel.currentHome = currentId;
        }

        public void SetPreviousHome(int previousId)
        {
            _matchModel.previousHome = previousId;
        }


		public bool GetNextHome(out int next)
        {
            for(int i = 0; i < _matchModel.players.Count; i++)
            {
                if (_matchModel.players[i] == _matchModel.currentHome)
                {
                    int cur = i;
                    if (cur == _matchModel.players.Count - 1)
                    {
                        cur = 0;
                    }
                    else
                    {
                        cur = cur + 1;
                    }
                    next = _matchModel.players[cur];
                    return true;
                }
            }
            next = -1;
            return false;
        }

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
            _matchModel.players.Add(entityId);
        }

        #endregion
    }
}


