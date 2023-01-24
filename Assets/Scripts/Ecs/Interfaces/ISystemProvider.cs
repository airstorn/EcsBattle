using Leopotam.Ecs;

namespace Ecs.Interfaces
{
    public interface ISystemProvider
    {
        EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame);
    }
}