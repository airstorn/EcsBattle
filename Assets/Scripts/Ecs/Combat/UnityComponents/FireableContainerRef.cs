using Ecs.Combat.Components;
using Ecs.Core.UnityElements;
using Ecs.Physics;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.UnityComponents
{
    public class FireableContainerRef : ViewComponent
    {
        [SerializeField]
        private FireableView _fireable;

        [SerializeField]
        private Transform _root;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var container = ref entity.Get<FireableContainer>();

            var instance = Instantiate(_fireable, _root);

            var instanceEntity = world.NewEntity();
            instanceEntity.Get<LevelEntityTag>();


            if (entity.Has<Fraction>())
            {
                instanceEntity.Get<Fraction>() = entity.Get<Fraction>();
            }

            instance.Initialize(instanceEntity, world);

            container.Fireable = instance.Entity;
        }
    }
}