using Ecs.Core.UnityElements;
using Ecs.GamePlay.Tags;
using Leopotam.Ecs;

namespace Ecs.GamePlay.UnityComponents
{
    public class DespawnOnDeathRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            entity.Get<DespawnOnDeath>();
        }
    }
}