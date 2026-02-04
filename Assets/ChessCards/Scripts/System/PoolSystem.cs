using System.Collections;
using System.Collections.Generic;
using QMVC;
using UnityEngine;

namespace ChessCards
{
    public class PoolSystem : AbstractSystem
    {
        AssetSystem _assetSystem;


        Transform poolRoot;


        protected override void OnInit()
        {
            _assetSystem = this.GetSystem<AssetSystem>();
            poolRoot = new GameObject("Pools").transform;
		}

    }

}


