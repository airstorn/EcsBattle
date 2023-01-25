using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.Tags
{
    public struct Triggered
    {
        public Collider Collider;
        public EcsEntity Other;
    }
}