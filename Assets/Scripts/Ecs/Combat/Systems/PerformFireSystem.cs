using Ecs.Combat.Components;
using Ecs.Combat.Events;
using Leopotam.Ecs;

namespace Ecs.Combat.Systems
{
    public class PerformFireSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PerformFire, FireableContainer> _signal = null;
        
        public void Run()
        {
            ProcessEventToFireable();
        }

        private void ProcessEventToFireable()
        {
            foreach (var i in _signal)
            {
                ref var container = ref _signal.Get2(i);

                if (container.Fireable.IsNull())
                {
                    continue;
                }

                container.Fireable.Get<PerformFire>();
            }
        }
    }
}