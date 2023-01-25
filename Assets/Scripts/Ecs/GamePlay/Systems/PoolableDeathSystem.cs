using Ecs.Core.Pools;
using Ecs.GamePlay.Events;
using Ecs.GamePlay.Tags;
using Leopotam.Ecs;

namespace Ecs.GamePlay.Systems
{
    public class PoolableDeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Poolable, DespawnOnDeath, Dead> _signal = null;
        
        public void Run()
        {
            foreach (var i in _signal)
            {
                ref var poolable = ref _signal.Get1(i);
                
                poolable.TargetPool.Push(_signal.GetEntity(i));
            }
        }
    }
}