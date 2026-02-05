using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class PoolSystem : AbstractSystem
    {
        AssetSystem _assetSystem;

        ComponentPool<SFXController> sfxPool;


        Transform poolRoot;


        protected override void OnInit()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            poolRoot = new GameObject("Pools").transform;


            Transform sfxParent = new GameObject(_assetSystem.sfx.GetType().Name).transform;
            sfxParent.SetParent(poolRoot);
            sfxPool = new ComponentPool<SFXController>(_assetSystem.sfx, sfxParent);
		}




        public void RecycleSFX(SFXController sfx)
        {
            sfxPool.Recycle(sfx);
        }


    }

}


