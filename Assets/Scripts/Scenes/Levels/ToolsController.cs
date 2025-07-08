using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsController : MonoBehaviour
{
    [SerializeField] private List<ButtonAndTool> _buttonsAndTools;
    [SerializeField] private Tool _selectTool;


    private void Awake()
    {
        foreach (var button in _buttonsAndTools) {
        //for (int i = 0; i < _buttonsAndTools.Count; i++)
        //{
            //var btnAndTool = _buttonsAndTools[i];
            //_buttonsAndTools[i]
            button._button.onClick.AddListener(
                () =>
                {
                    for (int j = 0; j < _buttonsAndTools.Count; j++)
                    {
                        _buttonsAndTools[j]._button.transform.localScale = Vector3.one;
                        _buttonsAndTools[j]._tool.gameObject.SetActive(false);
                    }
                    button._button.transform.localScale = Vector3.one * 1.2f;
                    button._tool.gameObject.SetActive(true);
                    _selectTool = button._tool;
                }
            );
        }
    }

    public void Tap()
    {
        _selectTool.Tap();
    }

}

[Serializable] 
public class ButtonAndTool
{
    public Button _button;
    public Tool _tool;
}
