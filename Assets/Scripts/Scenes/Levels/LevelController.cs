using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private BalanceConfig _balanceConfig;
    [SerializeField] private AllLevelsConfig _allLevelsConfig;
    [SerializeField] private LevelConfig _levelConfig; 
    [SerializeField] private Arc _arc;
    [SerializeField] private Bariers _bariers;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _looseWindow;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private TextMeshProUGUI _levelLabelText;
    [SerializeField] private GameObject _nextButton;

    [SerializeField] private List<Obstacle> _obstacles;


    private void Awake()
    {
        _bariers.ballCollisionBarierEvent += Loose;
        _arc.scoreGoalEvent += Win;
        _levelLabelText.text = $"LVL {_levelConfig.level.ToString()}";
        if (_levelConfig.sceneName == _allLevelsConfig.levels[_allLevelsConfig.levels.Count-1].sceneName) 
            _nextButton.SetActive(false);
        foreach (var obstacle in _obstacles)
            obstacle.Init(_levelConfig);
    }

    private void Win()
    {
        Time.timeScale = 0f;
        _levelConfig.status = true;
        if (!(_levelConfig.sceneName == _allLevelsConfig.levels[_allLevelsConfig.levels.Count - 1].sceneName))
            _allLevelsConfig.levels.First(e => e.level == _levelConfig.level + 1).status = true;
        _balanceConfig.Add(100);
        SaveLoadConfigsService.Instance.SaveAll();

        _winWindow.SetActive(true);
    }

    private void Loose()
    {
        _looseWindow.SetActive(true);
        _winWindow.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        _pauseWindow.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        _pauseWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(_allLevelsConfig.levels.First(e => e.level == _levelConfig.level+1).sceneName);
        Time.timeScale = 1f;
    }

    public void Again()
    {
        SceneManager.LoadSceneAsync(_levelConfig.sceneName);
        Time.timeScale = 1f;
    }
}
