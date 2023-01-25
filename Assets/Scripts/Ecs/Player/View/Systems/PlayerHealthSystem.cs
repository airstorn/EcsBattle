using Ecs.Buffs.Components;
using Ecs.Buffs.Events;
using Ecs.Player.Model.Tags;
using Ecs.UI;
using Ecs.UI.Tags;
using Leopotam.Ecs;

namespace Ecs.Player.View.Systems
{
    public class PlayerHealthSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, Health, HealthUpdated> _health;

        private readonly EcsFilter<PlayerUI, HealthView> _view;

        public void Run()
        {
            foreach (var i in _health)
            {
                ref var values = ref _health.Get2(i);

                foreach (var v in _view)
                {
                    ref var view = ref _view.Get2(v);
                    
                    view.View.Display(values.Current, values.Max);
                }
            }
        }
    }
}