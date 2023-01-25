using Ecs.Core.UnityElements;
using Ecs.SceneManagement.Components;
using Ecs.SceneManagement.Events;
using Ecs.SceneManagement.Extensions;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Ecs.SceneManagement.Systems
{
    public class LoadLevelSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<LevelEntityTag> _oldEntities = null;
        
        private readonly EcsFilter<LoadLevel, OnLoad> _signal = null;
        
        private readonly EcsFilter<LoadLevelOperation> _operations = null;

        private int _defaultIndex;

        private readonly EcsWorld _world = null;

        private bool _hasOpenedScene;
        
        public LoadLevelSystem(int defaultIndex)
        {
            _defaultIndex = defaultIndex;
        }
        
        public void Init()
        {
            SceneManagementExtension.LoadLevel(_world, _defaultIndex);
        }

        public void Run()
        {
            ProcessLoadLevel();
            ProcessOperations();
        }

        
        private void ProcessOperations()
        {
            foreach (var i in _operations)
            {
                ref var data = ref _operations.Get1(i);

                if (data.Operation.isDone)
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
                    
                    _operations.GetEntity(i).Destroy();
                    _world.NewEntity().Get<OnLevelSpawned>();
                    _hasOpenedScene = true;
                }
            }
        }

        private void ProcessLoadLevel()
        {
            foreach (var i in _signal)
            {
                ClearOldEntities();

                if (_hasOpenedScene)
                {
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                }
                
                ref var data = ref _signal.Get1(i);
                
                ref  var operation = ref _world.NewEntity().Get<LoadLevelOperation>();

                operation.Operation = SceneManager.LoadSceneAsync(data.Index, LoadSceneMode.Additive);
            }
        }

        private void ClearOldEntities()
        {
            foreach (var oldEntity in _oldEntities)
            {
                _oldEntities.GetEntity(oldEntity).Destroy();
            }
        }
    }
}