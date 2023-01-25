using Ecs.Core.UnityElements;
using Ecs.Enemy.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Enemy.UnityComponents
{
    public class EnemyPoolFactory : ViewComponent
    {
        [SerializeField]
        private EnemiesAsset _asset;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            foreach (var i in _asset.Items)
            {
                var poolObj = new GameObject($"Enemy pool {i.ID}");
                var pool = poolObj.AddComponent<EnemyPool>();
                
                var poolEntity = world.NewEntity();

                poolEntity.Get<LevelEntityTag>();
                
                pool.SetData(i.ID,i.PoolCount, i.Prefab);
                pool.Initialize(poolEntity, world);
            }
        }
    }
}