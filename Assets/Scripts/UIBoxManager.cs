
using System.Collections.Generic;
using UnityEngine;

public class UIBoxManager : MonoBehaviour
{
    public static UIBoxManager singleton;
    [HideInInspector] public BoxHandleOutput output;

    [HideInInspector] public BoxHandleInput input;

    private void Awake()
    {
        if (!singleton)
        {
            singleton = this;
        }
    }

    public List<Box> GetRootBoxes()
    {
        List<Box> boxes = new List<Box>(GetComponentsInChildren<Box>());
        boxes = boxes.FindAll(box => !box.inputHandles.Exists(input => input.isConnected));
        return boxes;
    }
}
