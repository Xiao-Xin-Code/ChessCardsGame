using System.Collections;
using System.Collections.Generic;
using QMVC;

namespace ChessCards
{
	public class MatchModel : AbstractModel
	{
		public BindableProperty<GameState> State = new BindableProperty<GameState>();
		public Dictionary<int, PlayerEntity> playerEntitys = new Dictionary<int, PlayerEntity>();
		public int prepareCount = 0;
		public int previousHome;
		public int currentHome;
		public int localHome;
		public List<int> previousCards = new List<int>();

		public List<int> players = new List<int>();

		protected override void OnInit()
		{

		}
	}
}

