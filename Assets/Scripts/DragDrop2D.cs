using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop2D : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Début du drag !");
        offset = transform.position - GetWorldPosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetWorldPosition(eventData.position) + offset;
    }

    Vector3 GetWorldPosition(Vector2 screenPoint)
    {
        float zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 screenPosWithZ = new Vector3(screenPoint.x, screenPoint.y, zDistance);
        return Camera.main.ScreenToWorldPoint(screenPosWithZ);
    }
}