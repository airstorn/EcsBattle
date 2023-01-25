using System.Collections.Generic;
using Ecs.Core.Pools;
using Ecs.Enemy.Tags;
using Ecs.Enemy.UnityComponents;
using Ecs.GamePlay.Components;
using Ecs.Navigation.Components;
using Ecs.Spawning.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.GamePlay.Systems
{
    public class EnemySpawnPointSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Pool, EnemyId> _pools = null;
        
        private readonly EcsFilter<PerformEnemySpawn> _trigger = null;
        
        private readonly EcsFilter<SpawnPoint, EnemySpawnPoint> _spawnPoints = null;

        public void Run()
        {
            foreach (var i in _trigger)
            {
                ref var data = ref _trigger.Get1(i);

                for (int j = 0; j < data.Count; j++)
                {
                    foreach (var p in _pools)
                    {
                        ref var id = ref _pools.Get2(p);
                        ref var pool = ref _pools.Get1(p);

                        if (id.ID != data.ID)
                        {
                            continue;
                        }

                        var enemyInstance = pool.PoolRef.Get();


                        var spawnPointEntity = GetRandomSpawnPoint();
                        
                        ref var point = ref spawnPointEntity.Get<SpawnPoint>();
                        
                        enemyInstance.Get<NavMeshMovable>().Agent.Warp(point.Point);
                    }
                }
            }
        }

        private EcsEntity GetRandomSpawnPoint()
        {
            return _spawnPoints.GetEntity(Random.Range(0, _spawnPoints.GetEntitiesCount()));
        }
    }
}