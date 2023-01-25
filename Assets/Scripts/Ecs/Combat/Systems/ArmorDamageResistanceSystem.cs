using Ecs.Buffs.Components;
using Ecs.Combat.Components;
using Leopotam.Ecs;

namespace Ecs.Combat.Systems
{
    public class ArmorDamageResistanceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ReceivedDamage, Armor> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damage = ref _filter.Get1(i);
                ref var armor = ref _filter.Get2(i);

                damage.Amount = (int)(damage.Amount * (1 - armor.ResistanceNormalized));
            }
        }
    }
}