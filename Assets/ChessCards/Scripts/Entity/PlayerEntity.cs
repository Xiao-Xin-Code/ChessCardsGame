using System;
using System.Collections.Generic;

namespace ChessCards
{

    public class PlayerEntity : BaseEntity
    {
        public int id;

        public PlayerRole Role { get; private set; } = PlayerRole.None;
        public List<int> HandCards { get; } = new List<int>();
        public List<int> SelectCards { get; } = new List<int>();

        event Action<PlayerRole> onRoleChangeEvent;
        event Action onTurnEvent;
        event Action<int> onAddHandCardEvent;
        event Action<int> onRemoveHandCardEvent;
        event Action onSelectChangeEvent;
		event Action<int> onAddSelectCardEvent;
		event Action<int> onRemoveSelectCardEvent;


        public void SetRole(PlayerRole role)
        {
            Role = role;
            onRoleChangeEvent?.Invoke(role);

		}

		public void AddHandCard(int id)
        {
            HandCards.Add(id);
            onAddHandCardEvent?.Invoke(id);
        }

        public void RemoveHandCard(int id)
        {
            HandCards.Remove(id);
            onRemoveHandCardEvent?.Invoke(id);
        }

        public void AddSelectCard(int id)
        {
            SelectCards.Add(id);
            onAddSelectCardEvent?.Invoke(id);
        }

        public void RemoveSelectCard(int id)
        {
            SelectCards.Remove(id);
            onRemoveSelectCardEvent?.Invoke(id);
        }



        public PlayerEntity(Action<PlayerRole> onRole = null, Action<int> addHand = null, Action<int> removeHand = null,Action selectEvent = null)
        {
            onRoleChangeEvent = onRole;
            //onTurnEvent = onTurn;
            onAddHandCardEvent = addHand;
            onRemoveHandCardEvent = removeHand;
            onSelectChangeEvent = selectEvent;
        }


        public void RegisterAddHandCard(Action<int> action)
        {

        }

        public void RegisterRemoveHandCard(Action<int> action)
        {

        }

        


    }

}

