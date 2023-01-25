using Ecs.Core.UnityElements;
using Ecs.Enemy.Tags;
using Ecs.Spawning.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Enemy.UnityComponents
{
    public class EnemySpawnPointRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var data = ref entity.Get<SpawnPoint>();
            data.Point = transform.position;
            entity.Get<EnemySpawnPoint>();
        }
    }
}