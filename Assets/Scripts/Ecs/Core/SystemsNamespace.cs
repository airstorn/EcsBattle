using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core
{
    public class SystemsNamespace : EcsSystemProvider
    {
        [SerializeField]
        private string _nameSpace;

        [SerializeField]
        private EcsSystemProvider[] _systems;
        
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, _nameSpace);

            foreach (var system in _systems)
            {
                systems.Add(system.GetSystems(world, mainSystems, endFrame));
            }

            return systems;
        }
    }
}