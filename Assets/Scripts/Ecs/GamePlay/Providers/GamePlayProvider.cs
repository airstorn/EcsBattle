using Ecs.Buffs.Components;
using Ecs.Core;
using Ecs.Core.Pools.Systems;
using Ecs.Enemy.Data;
using Ecs.GamePlay.Components;
using Ecs.GamePlay.Events;
using Ecs.GamePlay.Systems;
using Ecs.GamePlay.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.GamePlay
{
    public class GamePlayProvider : EcsSystemProvider
    {
        [SerializeField]
        private EnemiesAsset _enemies;

        [SerializeField]
        private int _maxEnemiesCount;
        
        public override EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame)
        {
            EcsSystems systems = new EcsSystems(world, "Enemies");

            systems.Add(new DeathEventSystem());
            
            systems.Add(new EnemySpawnSystem(_maxEnemiesCount));
            
            systems.Add(new EnemySpawnPointSystem());
            systems.Add(new MoveToTargetSystem());

            systems.Add(new ResetOnSpawnSystem<Health>());
            
            mainSystems.Inject(_enemies);

            endFrame.OneFrame<PerformEnemySpawn>();
            endFrame.OneFrame<SpawnEnemies>();
            endFrame.OneFrame<Dead>();
            
            return systems;
        }
    }
}