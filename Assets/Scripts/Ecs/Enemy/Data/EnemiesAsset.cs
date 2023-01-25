using System;
using Ecs.Core.UnityElements;
using UnityEngine;

namespace Ecs.Enemy.Data
{
    [CreateAssetMenu(menuName = "Game/Enemies/Variants Asset", order = 0)]
    public class EnemiesAsset : ScriptableObject
    {
        [Serializable]
        public class Item
        {
            [field: SerializeField]
            public int ID;
            
            [field: SerializeField]
            public int PoolCount;
            
            [field: SerializeField]
            public ViewEntity Prefab;
        }

        [field: SerializeField]
        public Item[] Items;
    }
}