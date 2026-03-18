using UnityEngine;

namespace Project.Features.DialogSystem
{

    public class SelectPanel : MonoBehaviour
    {
        [SerializeField] protected SelectCellController spyController;
        [SerializeField] protected SelectCellController killController;
        [SerializeField] protected ComicsController endComics;
        [SerializeField] protected int lastPhase = 3;

        private int comics = 0;

        private void OnEnable()
        {
            spyController.OnSelect += ClosePanel;
            killController.OnSelect += ClosePanel;
        }
        private void OnDisable()
        {
            spyController.OnSelect -= ClosePanel;
            killController.OnSelect -= ClosePanel;
        }

        private void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        public void OpenPanel(int id)
        {
            gameObject.SetActive(true);
            if (lastPhase > id)
            {
                spyController.gameObject.SetActive(true);
                spyController.SetEvent(id);
            }
            else
            {
                endComics.gameObject.SetActive(true);
                comics = id;
            }
        }
        public void OpenKillPanel()
        {
            killController.gameObject.SetActive(true);
            killController.SetEvent(comics);
        }
    }
}