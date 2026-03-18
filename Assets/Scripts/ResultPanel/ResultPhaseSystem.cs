using System;
using UnityEngine;

namespace Project.Features.DialogSystem
{
    public class ResultPhaseSystem : MonoBehaviour
    {
        [SerializeField] protected SpySystem spySystem;
        [SerializeField] protected EventSpyPanel spyPanel;
        [SerializeField] protected ResultPhasePanel resultPhasePanel;

        public event Action OnComplete;

        public void Open()
        {
            gameObject.SetActive(true);
            if (spySystem.CurrentPersonEvent != null)
            {
                spyPanel.SetData(spySystem.CurrentPersonEvent);
                spySystem.SetCurrentEvent(null);
            }
            resultPhasePanel.SetData();
        }

        public void CloseAllPanel()
        {
            spyPanel.gameObject.SetActive(false);
            resultPhasePanel.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        public void Complete()
        {
            OnComplete?.Invoke();
            CloseAllPanel();
        }
    }
}