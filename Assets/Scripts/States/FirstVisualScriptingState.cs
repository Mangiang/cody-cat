
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstVisualScriptingState : State
{
    private DialogBox dialogBox;
    ScriptEditor scriptEditor;
    FirstVisualScripting firstVisualScripting;

    List<Box> boxes;
    ButtonPressBox pressBox;
    IfBox ifBox;
    MoveBox moveBox;

    public override void EnterState()
    {
        Debug.Log("Entering First Visual Scripting");
        UIManager.singleton.consolePanel.SetActive(true);
        UIManager.singleton.firstVisualScripting.SetActive(true);

        scriptEditor = UIManager.singleton.consolePanel.GetComponent<ScriptEditor>();
        firstVisualScripting = UIManager.singleton.firstVisualScripting.GetComponent<FirstVisualScripting>();
        dialogBox = UIManager.singleton.firstVisualScripting.transform.Find("DialogArea/DialogBox").GetComponent<DialogBox>();


        scriptEditor.DisableButtons();
        scriptEditor.Init();
    }

    private void SetpIF()
    {
        scriptEditor.buttons[0].enabled = true;
        firstVisualScripting.IFMask.SetActive(true);
    }

    private void SetPress()
    {
        scriptEditor.buttons[0].enabled = false;
        scriptEditor.buttons[1].enabled = true;
        firstVisualScripting.IFMask.SetActive(false);
        firstVisualScripting.PressButtonMask.SetActive(true);
    }

    private void SetMOVE()
    {
        scriptEditor.buttons[1].enabled = false;
        scriptEditor.buttons[2].enabled = true;
        firstVisualScripting.PressButtonMask.SetActive(false);
        firstVisualScripting.MoveMask.SetActive(true);
    }

    private void SetKeyPress()
    {
        scriptEditor.buttons[2].enabled = false;
        firstVisualScripting.MoveMask.SetActive(false);
        firstVisualScripting.PanelMask.SetActive(true);
    }

    private void SetValidate()
    {
        scriptEditor.buttons[3].enabled = true;
        firstVisualScripting.PanelMask.SetActive(false);
        firstVisualScripting.ValidateMask.SetActive(true);
    }

    public override void Update()
    {
        if (dialogBox.dialogIdx <= 0)
        {
            SetpIF();
            if (UIBoxManager.singleton.GetRootBoxes().Count >= 1)
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 1)
        {
            SetPress();
            if (UIBoxManager.singleton.GetRootBoxes().Count >= 2)
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 2)
        {
            SetMOVE();
            if (UIBoxManager.singleton.GetRootBoxes().Count >= 3)
            {
                boxes = UIBoxManager.singleton.GetRootBoxes();
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 3)
        {
            SetKeyPress();
            if (pressBox == null)
            {
                pressBox = boxes.Find(box => box.boxType == BoxType.PRESS) as ButtonPressBox;
            }

            if (ifBox == null)
            {
                ifBox = boxes.Find(box => box.boxType == BoxType.IF) as IfBox;
            }

            if (moveBox == null)
            {
                moveBox = boxes.Find(box => box.boxType == BoxType.MOVE) as MoveBox;
            }

            if (pressBox.GetInputValue() == "d")
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 4)
        {
            if (ifBox.outputHandles.FindAll(handle => handle.input != null).Count > 0 && pressBox.inputHandles.FindAll(handle => handle.isConnected).Count > 0)
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 5)
        {
            if (ifBox.outputHandles.FindAll(handle => handle.input != null).Count > 1 && moveBox.inputHandles.FindAll(handle => handle.isConnected).Count > 0)
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 6)
        {
            if (moveBox.GetDirection() == Vector3.right)
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 7)
        {
            SetValidate();
            if (!UIManager.singleton.consolePanel.activeInHierarchy)
            {
                scriptEditor.EnableButtons();
                firstVisualScripting.DisableAllMasks();
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 8)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                TutoManager.singleton.blockConsole = true;
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 9)
        {
            if (dialogBox.isLineCompleted && Input.GetMouseButtonDown(0))
            {
                UIManager.singleton.stopExecution = true;
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 10 || dialogBox.dialogIdx == 11)
        {
            if (dialogBox.isLineCompleted && Input.GetMouseButtonDown(0))
            {
                dialogBox.ChangeDialog();
            }
        }
        else if (dialogBox.dialogIdx == 12)
        {
            if (dialogBox.DidFinish() && Input.GetMouseButtonDown(0))
            {
                UIManager.singleton.stopExecution = false;
                TutoManager.singleton.blockConsole = false;
                TutoManager.singleton.NextStatus(dialogBox.dialog.nextState);
            }
        }
    }

    public override void ExitState()
    {
        Debug.Log("Entering First Visual Scripting");
        UIManager.singleton.consolePanel.SetActive(false);
        UIManager.singleton.firstVisualScripting.SetActive(false);
    }

}