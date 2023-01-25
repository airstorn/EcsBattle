using UnityEngine;

namespace Ecs.Bullets.Interfaces
{
    public interface IBulletView
    {
        public void InitializeBullet(Vector3 spawnPos, Vector3 velocity);
    }
}