using Ecs.Core.Components;
using Ecs.Player.Model.Components;
using Leopotam.Ecs;

namespace Ecs.Player.Model.Systems
{
    public class LookAtSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnityView, LookAtDirection> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var view = ref _filter.Get1(i);
                ref var lookAtDirection = ref _filter.Get2(i);
                
                view.Transform.LookAt(lookAtDirection.Direction);
            }
        }
    }
}