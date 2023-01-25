using Ecs.Core.UnityElements;
using Ecs.Physics.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.UnityComponents
{
    public class CollisionListener : ViewComponent
    {
        public EcsEntity Entity;

        private void OnCollisionEnter(Collision collision)
        {
            if (Entity.IsNull())
            {
                return;
            }

            ViewEntity listener;

            ref var collided = ref Entity.Get<Collided>();
            collided.Collision = collision;

            if (collision.transform.TryGetComponent<ViewEntity>(out listener))
            {
                collided.Other = listener.Entity;
            }
            else
            {
                listener = collision.transform.GetComponentInParent<ViewEntity>();
                if (listener == null)
                {
                    collided.Other = EcsEntity.Null;
                }
                else
                {
                    collided.Other = listener.Entity;
                }
            }
        }

        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            Entity = entity;
        }
    }
}