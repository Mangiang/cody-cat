using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform dragRectTransform;
    private Canvas canvas;

    private bool isDragging;

    private Box box;

    private void Awake()
    {
        box = GetComponent<Box>();
        if (dragRectTransform == null)
        {
            dragRectTransform = transform.GetComponent<RectTransform>();
        }

        if (canvas == null)
        {
            Transform testCanvasTransform = transform.parent;
            while (testCanvasTransform != null)
            {
                canvas = testCanvasTransform.GetComponent<Canvas>();
                if (canvas != null)
                {
                    break;
                }
                testCanvasTransform = testCanvasTransform.parent;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            box.UpdateLine();
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        dragRectTransform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}