using Ecs.Core.UnityElements;
using Ecs.SceneManagement.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Ecs.UI.UnityComponents
{
    [RequireComponent(typeof(Button))]
    public class ReloadButton : ViewComponent
    {
        private EcsWorld _world;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            _world = world;
            GetComponent<Button>().onClick.AddListener(OnPressed);
        }

        private void OnPressed()
        {
            SceneManagementExtension.LoadLevel(_world, 1);
        }
    }
}