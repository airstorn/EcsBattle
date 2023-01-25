using Ecs.Core;
using UnityEngine;

namespace Zenject.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField]
        private EcsService _instance;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EcsService>()
                .FromInstance(_instance)
                .AsSingle()
                .NonLazy();
        }
    }
}