using Ecs.Core.UnityElements;
using Ecs.SceneManagement.Events;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Ecs.SceneManagement.Systems
{
    public class SceneEntitiesInitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OnLevelSpawned> _signal = null;

        private EcsWorld _world = null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
            {
                return;
            }

            var rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var rootGameObject in rootGameObjects)
            {
                var unityEntities = rootGameObject.GetComponentsInChildren<ViewEntity>();

                foreach (var unityEntity in unityEntities)
                {
                    var instance = _world.NewEntity();
                    instance.Get<LevelEntityTag>();
                    
                    unityEntity.Initialize(instance, _world);
                }
            }
        }
    }
}