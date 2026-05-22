using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop2D : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;
    Collider2D col;
    public string destinationTag = "DropZone";
    private Vector3 originalPosition;

    public bool onCase; 
    public bool wasOnCase;

    private void Awake()
    {
        col = GetComponent<Collider2D>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (onCase)
        {
            wasOnCase = true;
        }
        onCase = false;
        originalPosition = transform.position;
        offset = transform.position - GetWorldPosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetWorldPosition(eventData.position) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        col.enabled = false;

        Vector3 worldPointerPos = GetWorldPosition(eventData.position);
        RaycastHit2D hitInfo = Physics2D.Raycast(worldPointerPos, Vector2.zero);

        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                Debug.Log("Ntm");
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
                onCase = true;

            }
            else
            {
              transform.position = originalPosition;
              if(wasOnCase){
                onCase = true;
              }
            }
        
        }
         else
            {
              transform.position = originalPosition;
              if(wasOnCase){
                onCase = true;
              }
            }

        col.enabled = true;
    }

    Vector3 GetWorldPosition(Vector2 screenPoint)
    {
        float zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 screenPosWithZ = new Vector3(screenPoint.x, screenPoint.y, zDistance);
        return Camera.main.ScreenToWorldPoint(screenPosWithZ);
    }
}