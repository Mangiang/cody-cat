using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public List<BoxHandleInput> inputHandles = new List<BoxHandleInput>();
    public List<BoxHandleOutput> outputHandles = new List<BoxHandleOutput>();

    public RectTransform rectTransform;

    public BoxType boxType;

    protected virtual void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        foreach (BoxHandleInput input in inputHandles)
        {
            input.box = this;
        }

        foreach (BoxHandleOutput output in outputHandles)
        {
            output.box = this;
        }
    }

    public void UpdateLine()
    {
        foreach (BoxHandleInput input in inputHandles)
        {
            input.UpdateLine();
        }

        foreach (BoxHandleOutput output in outputHandles)
        {
            output.UpdateLine();
        }
    }

    public virtual bool Execute()
    {
        return false;
    }
}