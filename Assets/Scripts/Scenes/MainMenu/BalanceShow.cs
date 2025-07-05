using TMPro;
using UnityEngine;

public class BalanceShow : MonoBehaviour
{
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _balanceConfig.onChange += () => { _text.text = _balanceConfig.balance.ToString(); };
    }

    private void OnEnable()
    {
        _text.text = _balanceConfig.balance.ToString();
    }

}
