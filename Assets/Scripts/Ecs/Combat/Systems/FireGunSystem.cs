using Ecs.Bullets;
using Ecs.Bullets.Components;
using Ecs.Bullets.UnityComponents;
using Ecs.Combat.Components;
using Ecs.Combat.Events;
using Ecs.Core.Pools;
using Ecs.Physics;
using Leopotam.Ecs;

namespace Ecs.Combat.Systems
{
    public class FireGunSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PerformFire, BulletShootable> _bulletsFilter = null;

        private readonly EcsFilter<Pool, BulletTag> _pool;
        
        public void Run()
        {
            foreach (var i in _bulletsFilter)
            {
                ref var parameters = ref _bulletsFilter.Get2(i);

                foreach (var p in _pool)
                {
                    ref var pool = ref _pool.Get1(i);

                    var bulletEntity = pool.PoolRef.Get();

                    ref var damage = ref bulletEntity.Get<DamageContainer>();
                    damage.Value = parameters.Damage;

                    ref var view = ref bulletEntity.Get<BulletView>();

                    view.View.InitializeBullet(parameters.SpawnPoint.position, parameters.SpawnPoint.forward * parameters.BulletSpeed);

                    var entity = _bulletsFilter.GetEntity(i);
                    if (entity.Has<Fraction>())
                    {
                        bulletEntity.Get<Fraction>() = ~entity.Get<Fraction>();
                    }
                }
            }
        }
    }
}