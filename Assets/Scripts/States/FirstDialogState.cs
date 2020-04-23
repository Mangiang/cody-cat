using UnityEngine;
public class FirstDialogState : State
{
    private DialogBox dialogBox;

    public override void EnterState()
    {
        Debug.Log("Entering First dialog");
        UIManager.singleton.firstDialog.SetActive(true);
        dialogBox = UIManager.singleton.firstDialog.transform.Find("DialogArea/DialogBox").GetComponent<DialogBox>();
    }
    public override void Update()
    {
        if (dialogBox.DidFinish() && Input.GetKeyDown(KeyCode.E))
        {
            TutoManager.singleton.NextStatus(StateEnum.FIRST_VISUAL_SCRIPTING);
        }
    }

    public override void ExitState()
    {
        Debug.Log("Exiting First dialog");
        UIManager.singleton.firstDialog.SetActive(false);
    }

}