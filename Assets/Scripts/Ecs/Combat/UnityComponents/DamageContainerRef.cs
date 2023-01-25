using Ecs.Combat.Components;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.UnityComponents
{
    public class DamageContainerRef : ViewComponent
    {
        [SerializeField]
        private int _defaultValue;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var container = ref entity.Get<DamageContainer>();
            container.Value = _defaultValue;
        }
    }
}