using Ecs.Bullets.Components;
using Ecs.Bullets.Interfaces;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Bullets.UnityComponents
{
    public class BulletRef : ViewComponent,
        IBulletView
    {
        [SerializeField]
        private Rigidbody _body;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            entity.Get<BulletTag>();
            ref var view = ref entity.Get<BulletView>();
            view.View = this;
        }

        public void InitializeBullet(Vector3 spawnPos, Vector3 velocity)
        {
            transform.position = spawnPos;
            _body.velocity = velocity;
        }
    }
}