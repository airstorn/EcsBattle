using Ecs.Input.Enums;
using Ecs.Input.Systems;
using Leopotam.Ecs;

namespace Ecs.Input.Factories
{
    public class InputFactory
    {
        public static IEcsRunSystem Create(InputType type)
        {
            switch (type)
            {
                case InputType.Keyboard:
                case InputType.Mobile:
                    return new KeyboardInputSystem();

                default:
                    return new KeyboardInputSystem();
            }
        }
    }
}