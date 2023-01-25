using Ecs.Core.UnityElements;
using Ecs.Navigation.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Navigation.UnityComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshMovableRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var component = ref entity.Get<NavMeshMovable>();
            component.Agent = GetComponent<NavMeshAgent>();
        }
    }
}