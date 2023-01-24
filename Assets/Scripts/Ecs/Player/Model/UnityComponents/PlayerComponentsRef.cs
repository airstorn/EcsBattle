using Ecs.Core.UnityElements;
using Ecs.Navigation.Components;
using Ecs.Player.Model.Components;
using Ecs.Player.Model.Tags;
using Leopotam.Ecs;

namespace Ecs.Player.Model.UnityComponents
{
    public class PlayerComponentsRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            entity.Get<PlayerTag>();

            entity.Get<InputListener>();
            entity.Get<VelocityMovement>();
            entity.Get<LookAtDirection>();
        }
    }
}