using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Health.UnityComponents
{
    public class HealthRef : ViewComponent
    {
        [SerializeField]
        private int _max;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var hp = ref  entity.Get<Components.Health>();
            hp.Current = _max;
            hp.Max = _max;
        }
    }
}