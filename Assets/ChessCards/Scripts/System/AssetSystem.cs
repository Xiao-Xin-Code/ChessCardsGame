using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class AssetSystem : AbstractSystem
    {
        Dictionary<string, Sprite> roleMap = new Dictionary<string, Sprite>();
        Dictionary<string, Sprite> rankIcons = new Dictionary<string, Sprite>();

        public CardController mainCard { get; private set; }
        public RectTransform subCard { get; private set; }


        protected override void OnInit()
        {
			mainCard = Resources.Load<CardController>("MainCard");
            subCard = Resources.Load<RectTransform>("SubCard");

            Sprite[] roles = Resources.LoadAll<Sprite>("Icons/Roles");
            foreach (var item in roles) 
            {
                roleMap.Add(item.name, item);
            }

            Sprite[] ranks = Resources.LoadAll<Sprite>("Icons/Ranks");
            foreach (var item in ranks)
            {
                Debug.Log("Ìí¼Ó" + item.name);
                rankIcons.Add(item.name, item);
            }
        }



        public bool TryGetRoleIcon(string role,out Sprite sprite)
        {
            return roleMap.TryGetValue(role, out sprite);
        }

        public bool TryGetRankIcon(string rank, out Sprite sprite)
        {
            Debug.Log(rank+rankIcons.ContainsKey(rank));
            return rankIcons.TryGetValue(rank, out sprite);
        }
    }

}

