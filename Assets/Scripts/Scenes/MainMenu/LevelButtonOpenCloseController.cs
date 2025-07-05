using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButtonOpenCloseController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private GameObject _lockImage;
    private Button _button;


    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenScene);
    }

    private void OnEnable()
    {
        _button.interactable = _levelConfig.status;
        _lockImage.SetActive(!_levelConfig.status);
    }

    private void OpenScene()
    {
        SceneManager.LoadSceneAsync(_levelConfig.sceneName);
    }


}
