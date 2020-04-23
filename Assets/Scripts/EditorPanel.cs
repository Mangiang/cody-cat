using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorPanel : MonoBehaviour, IDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    List<Box> boxes;

    private Canvas canvas;

    private bool canDrag;

    private void Start()
    {
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

        DragHandler[] drags = transform.parent.GetComponentsInChildren<DragHandler>();
        boxes = new List<Box>();
    }

    public void RegisterWindow(Box newBox)
    {
        if (!boxes.Contains(newBox))
            boxes.Add(newBox);
    }
    public void UnRegisterWindow(Box box)
    {
        if (boxes.Contains(box))
            boxes.Remove(box);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            foreach (Box box in boxes)
            {
                box.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
                box.UpdateLine();
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        canDrag = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canDrag = false;
    }

}