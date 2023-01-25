using Ecs.Core.Components;
using Ecs.Enemy.Components;
using Ecs.Navigation.Components;
using Ecs.Player.Model.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.GamePlay.Systems
{
    public class MoveToTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, UnityView> _player = null;
        
        private readonly EcsFilter<TargetMovement, ChasePlayer> _movement = null;
        
        public void Run()
        {
            foreach (var i in _movement)
            {
                ref var movement = ref _movement.Get1(i);

                foreach (var p in _player)
                {
                    ref var playerView = ref _player.Get2(p);

                    movement.Target = playerView.Transform.position;
                }
            }
        }
    }
}