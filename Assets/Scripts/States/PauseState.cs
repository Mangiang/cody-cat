using UnityEngine;

public class PauseState : State
{
    public override void EnterState()
    {
        Debug.Log("Entering Pause");
        UIManager.singleton.pause.SetActive(true);
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Pause");
        UIManager.singleton.pause.SetActive(false);
    }
}
