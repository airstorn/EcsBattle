using Ecs.Combat.Components;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Combat.UnityComponents
{
    public class GunFacadeRef : ViewComponent
    {
        [SerializeField]
        private float _shootDelay;

        [SerializeField]
        private float _bulletSpeed;

        [SerializeField]
        private int _damage;

        [SerializeField]
        private Transform _spawnPoint;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var parameters = ref entity.Get<BulletShootable>();

            parameters.CooldownDelay = _shootDelay;
            parameters.BulletSpeed = _bulletSpeed;
            parameters.SpawnPoint = _spawnPoint;
            parameters.Damage = _damage;
        }
    }
}