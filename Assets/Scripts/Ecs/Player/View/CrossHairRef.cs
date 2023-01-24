using Ecs.Core.UnityElements;
using Ecs.UI;
using Leopotam.Ecs;

namespace Ecs.Player.View
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