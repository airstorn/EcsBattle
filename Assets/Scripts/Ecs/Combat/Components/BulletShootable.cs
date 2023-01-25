using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.Components
{
    public struct BulletShootable
    {
        public float CooldownDelay;

        public int Damage;

        public float BulletSpeed;

        public int BulletIndex;

        public Transform SpawnPoint;
    }
}