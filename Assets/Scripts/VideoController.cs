using Project.Features.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Zenject;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private string _sceneName="Game";
    
    [Inject] private AudioController _audioController;
    
    private void OnEnable()
    {
        _audioController.StopMusic();
        _videoPlayer.loopPointReached += OnVideoEnded;
        _videoPlayer.SetDirectAudioVolume(0, _audioController.SoundVolume);
    }

    public void OnVideoEnded(VideoPlayer source)
    {
        SceneManager.LoadScene(_sceneName);
    }

    private void OnDisable()
    {
        _videoPlayer.loopPointReached -= OnVideoEnded;
    }
}
