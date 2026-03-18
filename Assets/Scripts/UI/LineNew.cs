using TMPro;
using UnityEngine;

public class LineNew : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _lineText;
    [SerializeField] private RectTransform _lineRectTransform;

    public float LengthLine
    {
        get { return _lineRectTransform.rect.width; }
    }

    public RectTransform LineRectTransform { get => _lineRectTransform; set => _lineRectTransform = value; }

    public void SetText(string lineText)
    {
        _lineText.text = lineText;  
    }
}