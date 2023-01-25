using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Physics.Events
{
    public struct TriggerExit
    {
        public Collider Collider;
        public EcsEntity Other;
    }
}