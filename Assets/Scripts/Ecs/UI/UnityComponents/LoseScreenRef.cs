using Ecs.Core.UnityElements;
using Leopotam.Ecs;

namespace Ecs.UI.UnityComponents
{
    public class LoseScreenRef : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var component = ref entity.Get<LoseScreen>();
            component.Root = gameObject;
            
            gameObject.SetActive(false);
        }
    }
}