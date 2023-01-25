using Ecs.Enemy.Data;
using Ecs.Enemy.UnityComponents;
using Ecs.GamePlay.Components;
using Ecs.GamePlay.Events;
using Ecs.GamePlay.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.GamePlay.Systems
{
    public class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyId, Dead> _onDead = null;
        
        private readonly EcsFilter<SpawnEnemies> _spawnTrigger = null;

        private readonly EcsWorld _world = null;

        private readonly EnemiesAsset _enemies = null;
        
        private readonly int _initialCount;
        
        public EnemySpawnSystem(int initialInitialCount)
        {
            _initialCount = initialInitialCount;
        }
        
        public void Run()
        {
            ProcessSpawnTrigger();
            ProcessSpawnOnLastDeath();
        }

        private void ProcessSpawnOnLastDeath()
        {
            if (_onDead.IsEmpty())
            {
                return;
            }
            
            ref var spawn = ref _world.NewEntity().Get<PerformEnemySpawn>();
            spawn.Count = _onDead.GetEntitiesCount();
            spawn.ID = _enemies.Items[Random.Range(0, _enemies.Items.Length)].ID;
        }

        private void ProcessSpawnTrigger()
        {
            if (_spawnTrigger.IsEmpty())
            {
                return;
            }

            foreach (var enemy in _enemies.Items)
            {
                ref var spawn = ref _world.NewEntity().Get<PerformEnemySpawn>();
                spawn.Count = _initialCount / _enemies.Items.Length;
                spawn.ID = enemy.ID;
            }
        }
    }
}