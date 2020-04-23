using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "DialogData", menuName = "Dialog/DialogData", order = 0)]
public class DialogData : ScriptableObject
{
    public DialogLine[] lines = new DialogLine[0];

    public StateEnum nextState;

    public bool ChangeDialogOnClick;
}