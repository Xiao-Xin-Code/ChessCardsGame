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


        Dictionary<string, AudioClip> bgms = new Dictionary<string, AudioClip>();
        Dictionary<string, AudioClip> sfxs = new Dictionary<string, AudioClip>();



        public CardController mainCard { get; private set; }
        public RectTransform subCard { get; private set; }

        public SFXController sfx { get; private set; }


        protected override void OnInit()
        {
			mainCard = Resources.Load<CardController>("MainCard");
            subCard = Resources.Load<RectTransform>("SubCard");
            sfx = Resources.Load<SFXController>("SFX");

            Sprite[] roles = Resources.LoadAll<Sprite>("Icons/Roles");
            foreach (var item in roles) 
            {
                roleMap.Add(item.name, item);
            }

            Sprite[] ranks = Resources.LoadAll<Sprite>("Icons/Ranks");
            foreach (var item in ranks)
            {
                rankIcons.Add(item.name, item);
            }
        }



        public bool TryGetRoleIcon(string role,out Sprite sprite)
        {
            return roleMap.TryGetValue(role, out sprite);
        }

        public bool TryGetRankIcon(string rank, out Sprite sprite)
        {
            return rankIcons.TryGetValue(rank, out sprite);
        }

        public bool TryGetBGM(string clip)
        {
            return bgms.TryGetValue(clip, out AudioClip audioClip);
        }

        public bool TryGetSFX(string clip)
        {
            return sfxs.TryGetValue(clip, out AudioClip audioClip);
        }
    }

}

