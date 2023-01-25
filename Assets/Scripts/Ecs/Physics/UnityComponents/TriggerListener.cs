using Ecs.Core.UnityElements;
using Ecs.Physics.Events;
using Ecs.Physics.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.UnityComponents
{
    public class TriggerListener : ViewComponent
    {
        public EcsEntity Entity;

        private void OnTriggerEnter(Collider other)
        {
            if (Entity.IsNull())
            {
                return;
            }
            
            ViewEntity listener;

            if (other.TryGetComponent(out listener))
            {
                if (listener.Entity.Has<IgnoreInTrigger>())
                {
                    return;
                }
                
                ref var triggered = ref Entity.Get<Triggered>();
                triggered.Collider = other;
                triggered.Other = listener.Entity;
            }
            else
            {
                listener = other.GetComponentInParent<ViewEntity>();

                if (listener == null)
                {
                    return;
                }
                
                if (listener.Entity.Has<IgnoreInTrigger>())
                {
                    return;
                }
                ref var triggered = ref Entity.Get<Triggered>();
                triggered.Collider = other;
                if (listener == null)
                {
                    triggered.Other = EcsEntity.Null;
                }
                else
                {
                    triggered.Other = listener.Entity;
                }
            }
        } 
        
        private void OnTriggerExit(Collider other)
        {
            ViewEntity listener;


            if (other.TryGetComponent<ViewEntity>(out listener))
            {
                if (listener.Entity.Has<IgnoreInTrigger>())
                {
                    return;
                }
                
                ref var triggered = ref Entity.Get<TriggerExit>();
                triggered.Collider = other;
                triggered.Other = listener.Entity;
            }
            else
            {
                listener = other.GetComponentInParent<ViewEntity>();

                if (listener == null)
                {
                    return;
                }
                
                if (listener.Entity.Has<IgnoreInTrigger>())
                {
                    return;
                }
                
                 
                ref var triggered = ref Entity.Get<TriggerExit>();
                triggered.Collider = other;
                
                if (listener == null)
                {
                    triggered.Other = EcsEntity.Null;
                }
                else
                {
                    triggered.Other = listener.Entity;
                }
            }
        }

        public override void Initialize(EcsEntity entity, EcsWorld world)
        { 
            Entity = entity;
        }
    }
}