using Ecs.Buffs.Components;
using Ecs.Buffs.Events;
using Ecs.Combat.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.Systems
{
    public class HealthDamageInfluenceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ReceivedDamage, Health> _signal = null;

        public void Run()
        {
            foreach (var i in _signal)
            {
                ref var damage = ref _signal.Get1(i);
                ref var health = ref _signal.Get2(i);

                health.Current = Mathf.Clamp(health.Current - damage.Amount, 0, health.Max);

                _signal.GetEntity(i).Get<HealthUpdated>();
            }
        }
    }
}