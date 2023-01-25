using Ecs.Core;
using Ecs.Player.View.Systems;
using Leopotam.Ecs;

namespace Ecs.Player.View.Providers
{
    public class PlayerLateViewProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Player");

            systems.Add(new CrosshairSystem());

            return systems;
        }
    }
}