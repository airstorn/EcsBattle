using Ecs.Core;
using Ecs.Physics.Events;
using Ecs.Physics.Tags;
using Leopotam.Ecs;

namespace Ecs.Physics.Providers
{
    public class PhysicsProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Physics");

            endFrame.OneFrame<Collided>();
            endFrame.OneFrame<Triggered>();
            endFrame.OneFrame<TriggerExit>();

            return systems;
        }
    }
}