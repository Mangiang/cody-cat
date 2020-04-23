public class FinishedState : State
{
    public override void EnterState()
    {
        UIManager.singleton.finish.SetActive(true);
    }

    public override void Update()
    {
    }

    public override void ExitState()
    {
    }
}