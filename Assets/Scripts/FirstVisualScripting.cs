using UnityEngine;

public class FirstVisualScripting : MonoBehaviour
{
    public GameObject IFMask;
    public GameObject PressButtonMask;
    public GameObject MoveMask;
    public GameObject PanelMask;
    public GameObject ValidateMask;

    public GameObject Mask;

    private void Start()
    {
        IFMask.SetActive(false);
        PressButtonMask.SetActive(false);
        MoveMask.SetActive(false);
        PanelMask.SetActive(false);
        ValidateMask.SetActive(false);
    }

    public void DisableAllMasks()
    {
        IFMask.SetActive(false);
        PressButtonMask.SetActive(false);
        MoveMask.SetActive(false);
        PanelMask.SetActive(false);
        ValidateMask.SetActive(false);
        Mask.SetActive(false);
    }
}