using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Features.UI {
    public class ResCell : MonoBehaviour
    {
        [SerializeField] protected Image _iconRes;
        [SerializeField] protected TextMeshProUGUI _resText;

        public virtual void SetText(int dig)
        {
            _resText.text = dig > 0 ? $"+{dig}" : dig.ToString();
        }
    }
}