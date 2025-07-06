using System.Linq;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleConfig _obstacleConfig;
    private int _durability;

    [SerializeField] private TextMeshProUGUI _levelLabel;
    private int _level;

    [SerializeField] private RectTransform _durabilityBar;
    private float _lenDurabilityBar;


    public void Init(LevelConfig levelConfig)
    {
        _level = levelConfig.level;
        _durability = _obstacleConfig.obstacleLevels.First(e => e.level == _level).durability;
        _levelLabel.text = $"LVL {_level}";
        UpdateDurabilityBar();
    }

    private void UpdateDurabilityBar()
    {
        print(Vector3.one * ((float)_durability / (float)_obstacleConfig.obstacleLevels.First(e => e.level == _level).durability));
        _durabilityBar.localScale = Vector3.one * ((float)_durability / (float)_obstacleConfig.obstacleLevels.First(e => e.level == _level).durability);
    }

    public void GetDamage(int damage, ToolConfig tool)
    {
        if (_obstacleConfig.targetTool == tool)
        {
            _durability -= damage;
            UpdateDurabilityBar();
            CheckDurability();
        }
    }

    private void CheckDurability()
    {
        if (_durability <= 0)
            Destroy(this.gameObject);
    }
}
