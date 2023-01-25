using Ecs.Core.UnityElements;
using Leopotam.Ecs;

namespace Ecs.UI
{
    public class CrossHairRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var component = ref entity.Get<CrossHair>();
            component.Movable = transform;
        }
    }
}