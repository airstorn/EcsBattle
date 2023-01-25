using Ecs.Enemy.UnityComponents;
using Ecs.GamePlay.Events;
using Ecs.UI;
using Leopotam.Ecs;

namespace Ecs.Player.View.Systems
{
    public class KillCounterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyId, Dead> _signal = null;
        
        private readonly EcsFilter<KilledEnemiesCounter> _counter = null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
            {
                return;
            }

            foreach (var i in _counter)
            {
                ref var view = ref _counter.Get1(i);

                view.Count += _signal.GetEntitiesCount();
                
                view.Counter.text = string.Format(view.Format, view.Count);
            }
        }
    }
}