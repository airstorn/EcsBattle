using Ecs.Input.Tags;
using Ecs.Navigation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Navigation.Systems
{
    public class NavMeshSystems : IEcsRunSystem
    {
        private readonly EcsFilter<NavMeshMovable, VelocityMovement> _direction;
        
        private readonly EcsFilter<NavMeshMovable, TargetMovement>.Exclude<InputLocked> _targetable;
        
        public void Run()
        {
            foreach (var i in _targetable)
            {
                ref var agent = ref _targetable.Get1(i);
                ref var target = ref _targetable.Get2(i);

                agent.Agent.SetDestination(target.Target);
            }
            
            foreach (var i in _direction)
            {
                ref var agent = ref _direction.Get1(i);
                ref var velocity = ref _direction.Get2(i);
                
                agent.Agent.Move(velocity.Velocity * agent.Agent.speed * Time.deltaTime);
            }
        }
    }
}