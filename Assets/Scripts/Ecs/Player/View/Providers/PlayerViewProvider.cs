using Ecs.Core;
using Ecs.Player.View.Systems;
using Leopotam.Ecs;

namespace Ecs.Player.View.Providers
{
    public class PlayerViewProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Player");

            systems.Add(new PlayerDeathSystem());
            
            systems.Add(new PlayerHealthSystem());
            systems.Add(new KillCounterSystem());

            return systems;
        }
    }
}