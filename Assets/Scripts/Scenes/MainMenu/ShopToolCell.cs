using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopToolCell : MonoBehaviour
{
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private ToolConfig _toolConfig;

    [SerializeField] private TextMeshProUGUI _levelLabel;
    [SerializeField] private TextMeshProUGUI _costToUpdate;
    [SerializeField] private Button _button;


    private void Awake()
    {
        _button.onClick.AddListener(LevelUp);
    }

    private void OnEnable()
    {
        UpdateWindow();
    }

    private void UpdateWindow()
    {
        _levelLabel.text = "LEVEL " + _toolConfig.level;
        _costToUpdate.text = (
            _toolConfig.level == _toolConfig.toolLevels[_toolConfig.toolLevels.Count - 1].level ?
            "" : _toolConfig.toolLevels.First(e => e.level == _toolConfig.level + 1).cost.ToString()
        );
        if (_toolConfig.level == _toolConfig.toolLevels[_toolConfig.toolLevels.Count - 1].level)
        {
            _button.gameObject.SetActive(false);
        }
        else
        {
            _button.gameObject.SetActive(true);
        }
    }

    public void LevelUp()
    {
        if (_balanceConfig.balance >= _toolConfig.toolLevels[_toolConfig.toolLevels.Count - 1].cost)
        {
            _balanceConfig.Remove(_toolConfig.toolLevels[_toolConfig.toolLevels.Count - 1].cost);
            _toolConfig.level++;
        }
        UpdateWindow();
    }
}
