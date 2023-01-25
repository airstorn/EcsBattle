using Ecs.Core.Interfaces;
using Ecs.Core.Pools.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core.Pools.Systems
{
    public class ResetOnSpawnSystem<T> : IEcsRunSystem where T : struct, IResetable
    {
        private readonly EcsFilter<Poolable, Spawned, T> _signal = null;


        public void Run()
        {
            foreach (var i in _signal)
            {
                ref var component = ref _signal.Get3(i);
                
                component.Reset();
            }
        }
    }
}