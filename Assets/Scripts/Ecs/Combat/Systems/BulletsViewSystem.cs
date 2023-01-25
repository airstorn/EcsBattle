using Ecs.Bullets;
using Ecs.Combat.Events;
using Ecs.GamePlay.Events;
using Leopotam.Ecs;

namespace Ecs.Combat.Systems
{
    public class BulletsViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BulletTag, DamageSended> _signal = null;
        
        public void Run()
        {
            foreach (var i in _signal)
            {
                _signal.GetEntity(i).Get<Dead>();
            }
        }
    }
}