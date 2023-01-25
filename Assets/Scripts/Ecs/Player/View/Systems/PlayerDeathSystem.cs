using Ecs.Events;
using Ecs.GamePlay.Events;
using Ecs.Input.Tags;
using Ecs.Player.Model.Components;
using Ecs.Player.Model.Tags;
using Ecs.UI;
using Leopotam.Ecs;

namespace Ecs.Player.View.Systems
{
    public class PlayerDeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, Dead> _signal = null;

        //hardcode
        private readonly EcsFilter<LoseScreen> _loseScreen = null;

        private readonly EcsFilter<InputListener> _listeners = null;

        private EcsWorld _world = null;
        
        public void Run()
        {
            if (_signal.IsEmpty())
            {
                return;
            }

            var lose = _world.NewEntity();

            lose.Get<GameState>();
            lose.Get<Lose>();

            foreach (var i in _loseScreen)
            {
                ref var screen = ref _loseScreen.Get1(i);
                screen.Root.SetActive(true);
            }

            foreach (var listener in _listeners)
            {
                _listeners.GetEntity(listener).Get<InputLocked>();
            }
        }
    }
}