using Ecs.Input.Components;
using Ecs.Input.Tags;
using Ecs.Player.Model.Components;
using Ecs.Player.Model.Tags;
using Ecs.UI;
using Leopotam.Ecs;

namespace Ecs.Player.View.Systems
{
    public class CrosshairSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputTag, InputMouse> _input = null;
        
        private readonly EcsFilter<CrossHair> _view = null;
        
        public void Run()
        {
            foreach (var i in _input)
            {
                ref var input = ref _input.Get2(i);

                foreach (var v in _view)
                {
                    ref var view = ref _view.Get1(v);

                    view.Movable.position = input.ScreenPosition;
                }
            }
        }
    }
}