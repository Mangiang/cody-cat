using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxHandleInput : BoxHandle, IPointerEnterHandler, IPointerExitHandler
{
    public BoxHandleOutput output = null;
    public bool isConnected = false;

    public Box box;

    public void UpdateLine()
    {
        if (output != null)
        {
            output.UpdateLine();
        }
    }

    public void SetOutput(BoxHandleOutput output)
    {
        Attach(output);
        isConnected = true;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        boxManager.input = this;
        if (output != null)
        {
            output.Detach();
            output.UpdateLine();
            Detach();
        }
        isConnected = false;
    }

    public override void Attach(BoxHandle newOutput)
    {
        output = newOutput as BoxHandleOutput;
    }

    public override void Detach()
    {
        output = null;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        boxManager.input = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        boxManager.input = this;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        boxManager.input = null;
    }
}