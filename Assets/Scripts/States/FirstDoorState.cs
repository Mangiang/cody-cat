public class FirstDoorState : State
{
    public override void EnterState()
    {
        UIManager.singleton.stopExecution = false;
        TutoManager.singleton.blockConsole = false;
    }
    public override void Update()
    {
    }

    public override void ExitState()
    {
    }

}