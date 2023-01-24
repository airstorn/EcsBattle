using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Core.UnityElements
{
    public abstract class ViewComponent : MonoBehaviour
    {
        public abstract void Initialize(EcsEntity entity, EcsWorld world);
    }
}