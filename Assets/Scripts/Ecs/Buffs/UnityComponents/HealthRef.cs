using Ecs.Buffs.Components;
using Ecs.Buffs.Events;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Buffs.UnityComponents
{
    public class HealthRef : ViewComponent
    {
        [SerializeField]
        private int _max;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var hp = ref  entity.Get<Health>();
            hp.Current = _max;
            hp.Max = _max;

            entity.Get<HealthUpdated>();
        }
    }
}