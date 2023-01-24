using Ecs.Core;
using Ecs.Input.Enums;
using Ecs.Input.Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Input.SystemProviders
{
    public class InputSystemProvider : EcsSystemProvider
    {
        [SerializeField]
        private InputType _type;
        
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Input");

            var currentInput = InputFactory.Create(_type);
            
            systems.Add(currentInput);

            return systems;
        }
    }
}