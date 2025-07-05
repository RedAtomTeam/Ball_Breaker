using UnityEngine;

public class SaveLoadConfigsService : MonoBehaviour
{
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private AllLevelsConfig _allLevelsConfig;
    [SerializeField] private AllToolsConfig _allToolsConfig;

    private void Awake()
    {
        LoadAll();
        _balanceConfig.onChange += SaveAll;
    }

    public void SaveAll()
    {
        PlayerPrefs.SetInt("Balance", _balanceConfig.balance);

        foreach (var level in _allLevelsConfig.levels)
        {
            PlayerPrefs.SetInt($"{level.sceneName}_Status", level.status == true ? 1 : 0);
        }

        foreach (var tool in _allToolsConfig.toolConfigs)
        {
            PlayerPrefs.SetInt($"{tool.name}_Status", tool.level);
        }
    }

    public void LoadAll() 
    {
        _balanceConfig.balance = PlayerPrefs.GetInt("Balance", 0);

        foreach (var level in _allLevelsConfig.levels)
        {
            level.status = PlayerPrefs.GetInt($"{level.sceneName}_Status") == 1 ? true : false;
        }

        foreach (var tool in _allToolsConfig.toolConfigs)
        {
            tool.level = PlayerPrefs.GetInt($"{tool.name}_Status");
        }
    }
}
