using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private ToolConfig _toolConfig;
    [SerializeField] private Collider2D _destroyArea;

    private Collider2D[] _collidersInArea = new Collider2D[1];

    public void Tap()
    {
        print(_destroyArea.OverlapCollider(new ContactFilter2D(), _collidersInArea));
        if (_destroyArea.OverlapCollider(new ContactFilter2D(), _collidersInArea) > 0)
            _collidersInArea[0]?.GetComponent<Obstacle>()?.GetDamage(_toolConfig.Power, _toolConfig);
        AudioService.Instance.PlayEffect(_toolConfig.clip);
    }

}
