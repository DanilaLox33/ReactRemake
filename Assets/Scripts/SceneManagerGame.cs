using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManagerGame")]
public class SceneManagerGame : ScriptableObject
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
