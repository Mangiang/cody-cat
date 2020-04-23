using UnityEngine;
using UnityEngine.UI;

public class ScriptEditor : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        buttons = transform.GetComponentsInChildren<Button>();
        DisableButtons();
    }

    public void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
    }
}