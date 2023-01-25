using Ecs.Combat.Events;
using Ecs.Core.Components;
using Ecs.Input.Components;
using Ecs.Input.Events;
using Ecs.Input.Tags;
using Ecs.Navigation.Components;
using Ecs.Player.Model.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Player.Model.Systems
{
    public class InputToPlayerMediatorSystem : 
        IEcsInitSystem, 
        IEcsRunSystem
    {
        private readonly EcsFilter<InputTag, InputDirection> _input = null;

        private readonly EcsFilter<InputTag, InputMouse> _mouse = null;

        private readonly EcsFilter<MousePressed> _fire = null;

        private readonly EcsFilter<InputListener, UnityView, VelocityMovement, LookAtDirection>.Exclude<InputLocked> _character = null;

        private Camera _camera;
        
        public void Init()
        {
            _camera = Camera.main;
        }
        
        public void Run()
        {
            ProcessInput();
            ProcessFire();
        }

        private void ProcessFire()
        {
            if (_fire.IsEmpty())
            {
                return;
            }

            foreach (var i in _character)
            {
                _character.GetEntity(i).Get<PerformFire>();
            }
        }


        private void ProcessInput()
        {
            foreach (var i in _input)
            {
                ref var input = ref _input.Get2(i);

                foreach (var c in _character)
                {
                    ref var velocity = ref _character.Get3(c);

                    velocity.Velocity = new Vector3(input.Direction.x, 0, input.Direction.y);
                }
            }

            foreach (var i in _mouse)
            {
                ref var mouse = ref _mouse.Get2(i);

                foreach (var c in _character)
                {
                    ref var view = ref _character.Get2(c);
                    ref var lookAt = ref _character.Get4(c);

                    var characterScreenPos = _camera.WorldToScreenPoint(view.Transform.position);

                    Vector2 lookAtDirection = mouse.ScreenPosition - (Vector2)characterScreenPos;

                    lookAt.Direction = new Vector3(lookAtDirection.x, 0, lookAtDirection.y);
                }
            }
        }
    }
}