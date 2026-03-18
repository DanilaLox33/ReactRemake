using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] protected PlayerStat playerStat;
    [SerializeField] protected SceneManagerGame sceneManager;
    public void OpenEndPanel()
    {
        gameObject.SetActive(true);
        ShowEnd();
    }

    private void ShowEnd()
    {
        switch (playerStat.Power)
        {
            case <= 3:
                // Революция
                sceneManager.LoadScene("End1");
                break;
            case < 10:
                // Реакционер
                sceneManager.LoadScene("End2");
                break;
            default:
                // Процветание
                sceneManager.LoadScene("End3");
                break;
        }
    }
}
