using UnityEngine;

namespace Ecs.GamePlay.EnemySpawn
{
    public interface ISpawnSelector
    {
        public bool TryGetSpawnPoint(out Vector3 point);
    }
}