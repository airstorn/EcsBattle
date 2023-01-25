using Ecs.Combat.Systems;
using Ecs.Core;
using Ecs.GamePlay.Systems;
using Leopotam.Ecs;

namespace Ecs.Combat.Providers
{
    public class CombatViewSystem : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Combat View");

            systems.Add(new BulletsViewSystem());
            systems.Add(new PoolableDeathSystem());

            return systems;
        }
    }
}