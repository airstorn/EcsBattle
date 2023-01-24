using Ecs.SceneManagement.Components;
using Ecs.SceneManagement.Events;
using Leopotam.Ecs;

namespace Ecs.SceneManagement.Extensions
{
    public static class SceneManagementExtension
    {
        public static void LoadLevel(EcsWorld world, int index)
        {
            var entity = world.NewEntity();
            ref var parameters = ref entity.Get<LoadLevel>();
            parameters.Index = index;
            
            entity.Get<OnLoad>();
        }
    }
}