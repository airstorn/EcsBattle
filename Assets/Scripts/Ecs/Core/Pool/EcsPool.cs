using System.Collections.Generic;
using Ecs.Core.Components;
using Ecs.Core.Pools.Events;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core.Pools
{
    public abstract class EcsPool : ViewComponent
    {
        public abstract override void Initialize(EcsEntity ecsEntity, EcsWorld ecsWorld);

        public abstract void Push(EcsEntity entity);

        public abstract EcsEntity Get();
    }
    
    public abstract class EcsPool<T, TEntity> : EcsPool where T : ViewEntity where TEntity : struct
    {
        [SerializeField]
        protected int Count;

        [SerializeField]
        protected T Reference;
        
        protected Stack<EcsEntity> _waiting = new Stack<EcsEntity>();
        
        private EcsWorld _world;

        public override void Initialize(EcsEntity ecsEntity, EcsWorld ecsWorld)
        {
            ref var pool = ref ecsEntity.Get<Pool>();
            pool.PoolRef = this;
            _world = ecsWorld;
            for (int i = 0; i < Count; i++)
            {
                Add();
            }
        }
        
        private void Add()
        {
            var instance = Instantiate(Reference, transform);

            var newEntity = _world.NewEntity();

            newEntity.Get<LevelEntityTag>();
            ref var pullable = ref newEntity.Get<Poolable>();
            pullable.TargetPool = this;    
            
            instance.Initialize(newEntity, _world);
            OnInitialized(newEntity);
            Push(newEntity);
        }
        
        public override EcsEntity Get()
        {
            if (_waiting.Count == 0)
            {
                Add();
            }
            
            var current = _waiting.Pop();
            
            OnGet(current);

            return current;
        }

        public override void Push(EcsEntity ecsEntity)
        {
            if (ecsEntity.Has<TEntity>())
            {
                OnPush(ecsEntity);
                
                _waiting.Push(ecsEntity);
            }
        }

        protected virtual void OnInitialized(EcsEntity ecsEntity)
        {
            
        }

        protected virtual void OnGet(EcsEntity ecsEntity)
        {
            ref var view = ref ecsEntity.Get<UnityView>();
            view.GameObject.SetActive(true);

            ecsEntity.Get<Spawned>();
        }

        protected virtual void OnPush(EcsEntity ecsEntity)
        {
            ref var view = ref ecsEntity.Get<UnityView>();
            view.GameObject.SetActive(false);

            ecsEntity.Get<Despawned>();
        }
    }
}