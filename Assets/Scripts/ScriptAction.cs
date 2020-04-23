using UnityEngine;

public abstract class ScriptAction
{
    public GameObject target;
    public bool isFinished;
    public abstract void Init();

    public abstract void Update();
}