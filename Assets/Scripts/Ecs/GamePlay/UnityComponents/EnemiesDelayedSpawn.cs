using Ecs.Core.UnityElements;
using Ecs.GamePlay.Tags;
using Leopotam.Ecs;

namespace Ecs.GamePlay.UnityComponents
{
    public class EnemiesDelayedSpawn : ViewComponent
    {
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            world.NewEntity().Get<SpawnEnemies>();
        }
    }
}