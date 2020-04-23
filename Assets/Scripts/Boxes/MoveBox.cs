using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.InputField;

public class MoveBox : Box
{
    [SerializeField] private InputField inputFieldDirX;
    [SerializeField] private InputField inputFieldDirY;
    [SerializeField] private InputField inputFieldDirZ;

    [SerializeField] private Dropdown dropdown;

    private Dictionary<string, Controller> controllers = new Dictionary<string, Controller>();

    protected override void Start()
    {
        base.Start();
        boxType = BoxType.MOVE;
        inputFieldDirX.contentType = ContentType.DecimalNumber;
        inputFieldDirY.contentType = ContentType.DecimalNumber;
        inputFieldDirZ.contentType = ContentType.DecimalNumber;
        OnEnable();
    }

    private void OnEnable()
    {
        dropdown.options.Clear();
        controllers.Clear();
        foreach (Controller controller in LevelManager.singleton.movable)
        {
            controllers.Add(Localization.singleton.GetTranslation(controller.name), controller);
        }
        dropdown.AddOptions(controllers.Select(controller => controller.Key).ToList());
    }

    private Controller GetController()
    {
        return controllers[dropdown.options[dropdown.value].text];
    }

    public Vector3 GetDirection()
    {
        if (inputFieldDirX.text.Trim().Length == 0 || inputFieldDirY.text.Trim().Length == 0 || inputFieldDirZ.text.Trim().Length == 0)
            return Vector3.zero;
        return new Vector3(float.Parse(inputFieldDirX.text), float.Parse(inputFieldDirY.text), float.Parse(inputFieldDirZ.text));
    }

    public override bool Execute()
    {
        Controller controller = GetController();

        if (controller == null) return false;

        Vector3 dir = new Vector3(float.Parse(inputFieldDirX.text), float.Parse(inputFieldDirY.text), float.Parse(inputFieldDirZ.text));
        controller.Move(dir);

        return true;
    }
}