using Ecs.Core;
using Ecs.Navigation.Systems;
using Leopotam.Ecs;

namespace Ecs.Navigation.SystemProviders
{
    public class NavigationProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Navigation");

            systems.Add(new NavMeshSystems());

            return systems;
        }
    }
}