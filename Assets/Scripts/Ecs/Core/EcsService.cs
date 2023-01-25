using System;
using Leopotam.Ecs;

#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif

using UnityEngine;
using Zenject;

namespace Ecs.Core
{
    public class EcsService : MonoBehaviour,
        IInitializable,
        ITickable,
        IFixedTickable,
        ILateTickable
    {
        [SerializeField]
        private EcsSystemProvider[] _updateSystemProviders;
        
        [SerializeField]
        private EcsSystemProvider[] _fixedUpdateSystemProviders;
        
        [SerializeField]
        private EcsSystemProvider[] _lateUpdateSystemProviders;

        private EcsSystems _updateSystems;

        private EcsSystems _fixedUpdateSystems;
        
        private EcsSystems _lateUpdateSystems;
        
        private EcsWorld _world;
        
        public void Initialize()
        {
            _world = new EcsWorld();
            
            _updateSystems = CreateSystems(_updateSystemProviders, "Update");
            _fixedUpdateSystems = CreateSystems(_fixedUpdateSystemProviders, "FixedUpdate");
            _lateUpdateSystems = CreateSystems(_lateUpdateSystemProviders, "LateUpdate");
            
#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
#endif
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
            _lateUpdateSystems.Init();
        }

        private EcsSystems CreateSystems(EcsSystemProvider[] providers, string systemsName)
        {
            EcsSystems main = new EcsSystems(_world, systemsName);
            EcsSystems endFrame = new EcsSystems(_world, systemsName + "EndFrame");

            foreach (var provider in providers)
            {
                main.Add(provider.GetSystems(_world, main, endFrame));
            }

            main.Add(endFrame);
            
                        
#if UNITY_EDITOR
            EcsSystemsObserver.Create(main);
#endif
            
            return main;
        }

        public void Tick()
        {
            _updateSystems.Run();
        }

        public void FixedTick()
        {
            _fixedUpdateSystems.Run();
        }

        public void LateTick()
        {
            _lateUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            _world.Destroy();
            _world = null;
        }
    }
}
