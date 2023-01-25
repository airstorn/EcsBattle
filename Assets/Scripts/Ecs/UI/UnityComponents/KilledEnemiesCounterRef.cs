using Ecs.Core.UnityElements;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Ecs.UI.UnityComponents
{
    public class KilledEnemiesCounterRef : ViewComponent
    {
        [SerializeField]
        private TMP_Text _counter;

        [SerializeField]
        private string _format = "kills: {0}";
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            ref var counter = ref entity.Get<KilledEnemiesCounter>();
            counter.Counter = _counter;
            counter.Count = 0;
            counter.Format = _format;

            _counter.text = string.Format(_format, counter.Count);
        }
    }
}