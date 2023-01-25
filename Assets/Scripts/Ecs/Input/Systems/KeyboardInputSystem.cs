using Ecs.Input.Components;
using Ecs.Input.Enums;
using Ecs.Input.Events;
using Ecs.Input.Interfaces;
using Ecs.Input.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Input.Systems
{
    public class KeyboardInputSystem :
        IInputService,
        IEcsRunSystem
    {
        private readonly EcsFilter<InputTag, InputDirection> _direction = null;
        
        private readonly EcsFilter<InputTag, InputMouse> _mouse = null;

        private readonly EcsWorld _world = null;
        
        public InputType Type => InputType.Keyboard;

        public void Run()
        {
           ProcessDirection();
           ProcessMouse();
           ProcessFire();
        }

        private void ProcessFire()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _world.NewEntity().Get<MousePressed>();
            }
        }

        private void ProcessMouse()
        {
            Vector2 screenPos = UnityEngine.Input.mousePosition;

            if (_mouse.IsEmpty())
            {
                var entity = _world.NewEntity();
                entity.Get<InputTag>();
                ref var directionComponent = ref entity.Get<InputMouse>();

                directionComponent.ScreenPosition = screenPos;
            }
            else
            {
                foreach (var i in _mouse)
                {
                    ref var directionComponent = ref _mouse.Get2(i);

                    directionComponent.ScreenPosition = screenPos;
                }
            }
        }

        private void ProcessDirection()
        {
            Vector2 direction = new Vector2(UnityEngine.Input.GetAxis("Horizontal"),UnityEngine.Input.GetAxis("Vertical"));

            if (_direction.IsEmpty())
            {
                var entity = _world.NewEntity();
                entity.Get<InputTag>();
                ref var directionComponent = ref entity.Get<InputDirection>();

                directionComponent.Direction = direction;
            }
            else
            {
                foreach (var i in _direction)
                {
                    ref var directionComponent = ref _direction.Get2(i);

                    directionComponent.Direction = direction;
                }
            }
        }
    }
}