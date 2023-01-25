using Ecs.Core.UnityElements;
using Ecs.Enemy.Components;
using Ecs.Navigation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Enemy.UnityComponents
{
    public class EnemyComponentsRef : ViewComponent
    {
        [SerializeField]
        private int _id;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var id = ref entity.Get<EnemyId>();
            id.ID = _id;

            entity.Get<TargetMovement>();
            entity.Get<ChasePlayer>();
        }
    }
}