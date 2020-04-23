using UnityEngine;

public class IntroState : State
{
    public override void EnterState()
    {
        Debug.Log("Entering Intro");
        UIManager.singleton.introDialog.SetActive(true);
    }
    public override void Update()
    {
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Intro");
        UIManager.singleton.introDialog.SetActive(false);
    }

}