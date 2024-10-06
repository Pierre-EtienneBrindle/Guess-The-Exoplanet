using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]
public class AstralStructure : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] AstralStructureType type;
    [field: SerializeField] public float Radius { get; private set; } = 1;

    private void Awake()
    {
        transform.localScale = Vector3.one * Radius;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StarCounterMGManager.Instance?.OnAstralObjectDetected(type);
        //Can add a visual if doesn't want to delete
        Destroy(this);
    }
}

public enum AstralStructureType
{
    Moon,
    Star,
    Planet
}
