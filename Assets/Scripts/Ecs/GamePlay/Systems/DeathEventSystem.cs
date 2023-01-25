using Ecs.Buffs.Components;
using Ecs.Buffs.Events;
using Ecs.Core.Pools;
using Ecs.GamePlay.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.GamePlay.Systems
{
    public class DeathEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Health, HealthUpdated> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var hp = ref _filter.Get1(i);

                if (hp.Current == 0)
                {
                    _filter.GetEntity(i).Get<Dead>();
                }
            }
        }
    }
}