using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.Events
{
    public struct Collided
    {
        public Collision Collision;

        public EcsEntity Other;
    }
}