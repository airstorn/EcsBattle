using Ecs.Core;
using Ecs.SceneManagement.Events;
using Ecs.SceneManagement.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.SceneManagement.SystemProviders
{
    public class SceneManagementProvider : EcsSystemProvider
    {
        [SerializeField]
        private int _defaultSceneIndex;
        
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "SceneManagement");

            systems.Add(new LoadLevelSystem(_defaultSceneIndex));
            systems.Add(new SceneEntitiesInitSystem());

            endFrame.OneFrame<OnLoad>();
            endFrame.OneFrame<OnLevelSpawned>();
            return systems;
        }
    }
}