using UnityEngine;
using UnityEngine.UI;

namespace Project.Features.UI
{
    public sealed class ResCellSlider : ResCell
    {
        [SerializeField] private PlayerStat _stat;
        [SerializeField] private Slider _slider;

        private void Awake()
        {
            SetText(_stat.Power);
        }

        private void OnEnable()
        {
            _stat.OnPowerChange += SetText;
        }

        private void OnDisable()
        {
            _stat.OnPowerChange -= SetText;
        }

        public override void SetText(int dig)
        {
            _slider.value = dig;
            _resText.text = dig.ToString();
        }
    }
}