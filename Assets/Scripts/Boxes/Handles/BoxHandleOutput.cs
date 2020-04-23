using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class BoxHandleOutput : BoxHandle
{
    protected List<Vector2> lineEnds = new List<Vector2>();

    public BoxHandleInput input = null;

    private Vector2 currLineEnd = Vector2.zero;

    public Box box;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (input != null)
        {
            input.Detach();
            Detach();
            currLineEnd = eventData.position;
            UpdateLine();
        }
        boxManager.output = this;
        isDragging = true;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        if (isDragging)
            currLineEnd = eventData.position;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        isDragging = false;

        if (boxManager.input != null && boxManager.input.handleType == handleType)
        {
            Attach(boxManager.input);
            boxManager.input.SetOutput(this);
            lineEnds.Add(boxManager.input.GetComponent<RectTransform>().position);
        }

        currLineEnd = Vector2.zero;
        boxManager.input = null;
        boxManager.output = null;
    }

    public override void Attach(BoxHandle newInput)
    {
        input = newInput as BoxHandleInput;
    }

    public override void Detach()
    {
        input = null;
    }

    public void UpdateLine()
    {
        lineEnds.Clear();
        if (input != null)
            lineEnds.Add(input.GetComponent<RectTransform>().position);
    }

    protected virtual void OnGUI()
    {
        if (lineEnds.Count > 0)
        {
            Vector2 pos = rectTransform.position;
            pos.y = Screen.height - pos.y;

            foreach (Vector2 lineEnd in lineEnds)
            {
                Vector2 linePos = lineEnd;
                linePos.y = Screen.height - linePos.y;
                Drawing.DrawLine(pos, linePos, Color.blue, 3);
            }
        }

        if (currLineEnd != Vector2.zero)
        {
            Vector2 pos = rectTransform.position;
            pos.y = Screen.height - pos.y;
            Vector2 linePos = currLineEnd;
            linePos.y = Screen.height - linePos.y;
            Drawing.DrawLine(pos, linePos, Color.blue, 3);
        }
    }
}