using Ecs.Combat.Components;
using Ecs.Combat.Events;
using Ecs.Physics.Events;
using Ecs.Physics.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.Systems
{
    public class CollisionDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Collided, DamageContainer> _collisionSignal = null;
        private readonly EcsFilter<Triggered, DamageContainer> _triggeredSignal = null;

        public void Run()
        {
            ProcessTrigger();
            ProcessCollision();
        }

        private void ProcessTrigger()
        {
            foreach (var i in _triggeredSignal)
            {
                ref var collided = ref _triggeredSignal.Get1(i);
                ref var data = ref _triggeredSignal.Get2(i);

                if (collided.Other.IsNull())
                {
                    continue;
                }
                
                ref var receivedDamage = ref collided.Other.Get<ReceivedDamage>();
                receivedDamage.Amount = data.Value;

                _triggeredSignal.GetEntity(i).Get<DamageSended>();
            }
        }

        private void ProcessCollision()
        {
            foreach (var i in _collisionSignal)
            {
                ref var collided = ref _collisionSignal.Get1(i);
                ref var data = ref _collisionSignal.Get2(i);

                if (collided.Other.IsNull())
                {
                    continue;
                }
                
                ref var receivedDamage = ref collided.Other.Get<ReceivedDamage>();
                receivedDamage.Amount = data.Value;

                _collisionSignal.GetEntity(i).Get<DamageSended>();
            }
        }
    }
}