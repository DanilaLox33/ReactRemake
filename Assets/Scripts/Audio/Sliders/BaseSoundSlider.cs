using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Features.Game
{

    /// <summary>
    /// ������� ��� ������ �� ������.
    /// </summary>
    public class BaseSoundSlider : MonoBehaviour
    {
        [SerializeField] protected Slider slider;
        [SerializeField] protected Image image;
        [Inject] protected AudioController audioController;
        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(SetSound);
            SetValue();
        }

        /// <summary>
        /// ������ ������ �� ����� ��������.
        /// </summary>
        protected virtual void SetValue()
        {
            slider.value = audioController.SoundVolume;
            image.fillAmount = slider.value;
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SetSound);
        }

        /// <summary>
        /// ������ ���������� �����.
        /// </summary>
        /// <param name="arg0">�������� �����</param>
        protected virtual void SetSound(float arg0)
        {
            audioController.SetSoundVolume(arg0);
            image.fillAmount = slider.value;
        }
    }
}