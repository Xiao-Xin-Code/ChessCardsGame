using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class AssetSystem : AbstractSystem
    {
        Dictionary<string, Sprite> roleMap = new Dictionary<string, Sprite>();


        public CardController card { get; private set; }


        protected override void OnInit()
        {
			card = Resources.Load<CardController>("Card");

            Sprite[] roles = Resources.LoadAll<Sprite>("Icons/Roles");
            foreach (var item in roles) 
            {
                roleMap.Add(item.name, item);
            }
        }



        public bool TryGetRoleIcon(string role,out Sprite sprite)
        {
            return roleMap.TryGetValue(role, out sprite);
        }
    }

}

