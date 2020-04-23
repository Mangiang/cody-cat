using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager singleton;

    public GameObject consolePanel;
    public GameObject introDialog;
    public GameObject firstDialog;
    public GameObject firstVisualScripting;
    public GameObject finish;

    public GameObject pause;

    public UIBoxManager boxManager;

    [HideInInspector]
    public List<Box> boxesToExecute;

    public bool stopExecution;

    private void Awake()
    {
        singleton = this;
        consolePanel.SetActive(false);
        introDialog.SetActive(false);
        firstDialog.SetActive(false);
        firstVisualScripting.SetActive(false);
        pause.SetActive(false);
        finish.SetActive(false);
    }

    private void Start()
    {
    }

    public void ToggleConsole()
    {
        consolePanel.SetActive(!consolePanel.activeSelf);
    }

    public void HideConsole()
    {
        consolePanel.SetActive(false);
        boxesToExecute = boxManager.GetRootBoxes();
    }
    public void ShowConsole()
    {
        consolePanel.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (!consolePanel.activeInHierarchy && !stopExecution)
        {
            foreach (Box box in boxesToExecute)
            {
                box.Execute();
            }
        }
    }
}