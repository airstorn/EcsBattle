using Ecs.Physics;
using Ecs.Physics.Events;
using Ecs.Physics.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.Systems
{
    public class CollisionFractionSortSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Collided, Fraction> _collisionSignal = null;
        
        private readonly EcsFilter<Triggered, Fraction> _triggerSignal = null;

        public void Run()
        {
            ProcessTrigger();
            ProcessCollision();
        }

        private void ProcessTrigger()
        {
            foreach (var i in _triggerSignal)
            {
                ref var collided = ref _triggerSignal.Get1(i);
                ref var fraction = ref _triggerSignal.Get2(i);

                if (collided.Other.IsNull())
                {
                    continue;
                }
                
                if (collided.Other.Has<Fraction>())
                {
                    ref var otherFraction = ref collided.Other.Get<Fraction>();
                    
                    if((fraction & otherFraction) == 0)
                    {
                        _triggerSignal.GetEntity(i).Del<Triggered>();
                    }
                }
            }
        }

        private void ProcessCollision()
        {
            foreach (var i in _collisionSignal)
            {
                ref var collided = ref _collisionSignal.Get1(i);
                ref var fraction = ref _collisionSignal.Get2(i);

                if (collided.Other.IsNull())
                {
                    continue;
                }
                
                if (collided.Other.Has<Fraction>())
                {
                    ref var otherFraction = ref collided.Other.Get<Fraction>();
                    
                    if((fraction & otherFraction) == 0)
                    {
                        _collisionSignal.GetEntity(i).Del<Collided>();
                    }
                }
            }
        }
    }
}