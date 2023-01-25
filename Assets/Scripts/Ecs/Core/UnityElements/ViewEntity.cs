using Ecs.Core.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core.UnityElements
{
    public class ViewEntity : MonoBehaviour
    {
        [SerializeField]
        private ViewComponent[] _components;
        
        public EcsEntity Entity { get; private set; }
        
        
        public void Initialize(EcsEntity entity, EcsWorld world)
        {
            Entity = entity;

            ref var view = ref entity.Get<UnityView>();
            view.Transform = transform;
            view.GameObject = gameObject;

            foreach (var component in _components)
            {
                component.Initialize(entity, world);
            }
        }
    }
}