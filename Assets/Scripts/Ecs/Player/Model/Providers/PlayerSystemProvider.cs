using Ecs.Core;
using Ecs.Player.Model.Systems;
using Leopotam.Ecs;

namespace Ecs.Player.Model.Providers
{
    public class PlayerSystemProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Player");

            systems.Add(new InputToPlayerMediatorSystem());
            systems.Add(new LookAtSystem());

            return systems;
        }
    }
}