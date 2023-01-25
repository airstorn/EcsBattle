using Ecs.Core.Pools;
using Ecs.Core.UnityElements;
using Ecs.Input.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Enemy.UnityComponents
{
    public class EnemyPool : EcsPool<ViewEntity, EnemyId>
    {
        [SerializeField]
        private int _id;

        public void SetData(int id, int size, ViewEntity enemy)
        {
            _id = id;
            Count = size;
            Reference = enemy;
        }
        
        public override void Initialize(EcsEntity ecsEntity, EcsWorld ecsWorld)
        {
            ref var id = ref ecsEntity.Get<EnemyId>();

            id.ID = _id;
            
            base.Initialize(ecsEntity, ecsWorld);
        }

        protected override void OnInitialized(EcsEntity ecsEntity)
        {
            ref var id = ref ecsEntity.Get<EnemyId>();
            id.ID = _id;
        }

        protected override void OnGet(EcsEntity ecsEntity)
        {
            base.OnGet(ecsEntity);
            ecsEntity.Del<InputLocked>();
        }

        protected override void OnPush(EcsEntity ecsEntity)
        {
            base.OnPush(ecsEntity);
            ecsEntity.Get<InputLocked>();
        }
    }
}