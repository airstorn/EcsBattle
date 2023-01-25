using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.UnityComponents
{
    public class FractionRef : ViewComponent
    {
        [SerializeField]
        private Fraction _fraction;
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var v = ref entity.Get<Fraction>();
            v = _fraction;
        }
    }
}