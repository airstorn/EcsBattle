using Ecs.Core.UnityElements;
using Ecs.Player.Model.Tags;
using Ecs.UI.Interfaces;
using Ecs.UI.Tags;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ecs.UI.UnityComponents
{
    public class PlayerHealthBarView : ViewComponent,
        IHealthView
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private Image _bar;
        
        public override void Initialize(EcsEntity entity, EcsWorld world)
        {
            entity.Get<PlayerUI>();
            ref var bar = ref entity.Get<HealthView>();

            bar.View = this;
        }

        public void Display(int current, int max)
        {
            _text.text = current.ToString();
            _bar.fillAmount = current / (float)max;
        }
    }
}