using UnityEngine;
using UnityEngine.UI;

public class IfBox : Box
{
    [SerializeField] private BoxHandleOutput condition;
    [SerializeField] private BoxHandleOutput trueBranch;
    [SerializeField] private BoxHandleOutput falseBranch;

    protected override void Start()
    {
        base.Start();

        boxType = BoxType.IF;
    }

    public override bool Execute()
    {
        if (condition.input == null || trueBranch.input == null) return false;

        if (condition.input.box.Execute())
        {
            return trueBranch.input.box.Execute();
        }
        else
        {
            if (falseBranch != null && falseBranch.input != null)
                return falseBranch.box.Execute();
        }

        return false;
    }
}