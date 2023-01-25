using Ecs.Buffs.Events;
using Ecs.Combat.Components;
using Ecs.Combat.Events;
using Ecs.Combat.Systems;
using Ecs.Core;
using Leopotam.Ecs;

namespace Ecs.Combat.Providers
{
    public class CombatProvider : EcsSystemProvider
    {
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Combat");

            systems.Add(new PerformFireSystem());
            systems.Add(new FireGunSystem());
            
            systems.Add(new CollisionFractionSortSystem());
            systems.Add(new CollisionDamageSystem());
            systems.Add(new ArmorDamageResistanceSystem());
            systems.Add(new HealthDamageInfluenceSystem());

            endFrame.OneFrame<ReceivedDamage>();
            endFrame.OneFrame<DamageSended>();
            endFrame.OneFrame<HealthUpdated>();
            endFrame.OneFrame<PerformFire>();

            return systems;
        }
    }
}