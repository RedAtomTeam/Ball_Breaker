using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private ToolConfig _toolConfig;
    [SerializeField] private Collider2D _destroyArea;

    private Collider2D[] _collidersInArea = new Collider2D[1];

    public void Tap()
    {
        _destroyArea.OverlapCollider(new ContactFilter2D(), _collidersInArea);
        _collidersInArea[0]?.GetComponent<Obstacle>().GetDamage(_toolConfig.Power, _toolConfig);
    }

}
