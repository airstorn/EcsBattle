using Ecs.Buffs.Components;
using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Buffs.UnityComponents
{
    public class ArmorRef : ViewComponent
    {
        [SerializeField, Range(0, 1f)]
        private float _resistance;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var parameters = ref entity.Get<Armor>();
            parameters.ResistanceNormalized = _resistance;
        }
    }
}