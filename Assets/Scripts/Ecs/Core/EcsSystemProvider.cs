using Ecs.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core
{
    public abstract class EcsSystemProvider : MonoBehaviour, ISystemProvider
    {
        public abstract EcsSystems GetSystems(EcsWorld world, EcsSystems mainSystems, EcsSystems endFrame);
    }
}