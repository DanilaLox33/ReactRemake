using TMPro;
using UnityEngine;
using Zenject;

public sealed class MoneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    [Inject] private PlayerStat _playerStat;

    private void Awake()
    {
        _moneyText.text=_playerStat.Money.ToString();
    }

    private void OnEnable()
    {
        _playerStat.OnMoneyChange += SetText;
    }

    private void OnDisable()
    {
        _playerStat.OnMoneyChange -= SetText;
    }

    private void SetText(int money)
    {
        _moneyText.text=money.ToString();
    }
}
