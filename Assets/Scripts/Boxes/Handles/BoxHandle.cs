using UnityEngine;
using UnityEngine.EventSystems;

public class BoxHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected Canvas canvas;
    protected UIBoxManager boxManager;
    protected RectTransform rectTransform;

    public BoxHandleType handleType;

    protected bool isDragging;

    public GameObject lineConnectorPrefab;

    protected void Awake()
    {
        boxManager = UIBoxManager.singleton;
        rectTransform = GetComponent<RectTransform>();
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

    public virtual void Attach(BoxHandle newInput)
    {
    }

    public virtual void Detach()
    {
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        eventData.Use();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        eventData.Use();
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        eventData.Use();
    }
}