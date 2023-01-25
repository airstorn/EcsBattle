using Ecs.Core.Pools;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;

namespace Ecs.Bullets.UnityComponents
{
    public class BulletsPool : EcsPool<ViewEntity, BulletTag>
    {
        public override void Initialize(EcsEntity ecsEntity, EcsWorld ecsWorld)
        {
            base.Initialize(ecsEntity, ecsWorld);
            ecsEntity.Get<BulletTag>();
        }
    }
}