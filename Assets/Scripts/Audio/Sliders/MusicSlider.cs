using Zenject;

namespace Project.Features.Game
{
    /// <summary>
    /// Музыкальный слайдер.
    /// </summary>
    public class MusicSlider : BaseSoundSlider
    {
        protected override void SetValue()
        {
            slider.value = audioController.MusicVolume;
            image.fillAmount = slider.value;
        }

        protected override void SetSound(float arg0)
        {
            audioController.SetMusicVolume(arg0);
            image.fillAmount = slider.value;
        }
    }
}