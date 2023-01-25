using Ecs.Core.Pools.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core
{
    public class CoreProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems pool = new EcsSystems(world, "Pool");

            mainSystems.Inject(Camera.main);
            
            mainSystems.OneFrame<Despawned>();
            mainSystems.OneFrame<Spawned>();

            return pool;
        }
    }
}