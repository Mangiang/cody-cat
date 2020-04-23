using UnityEngine;
using UnityEngine.UI;

public class ButtonPressBox : Box
{
    [SerializeField] private int maxCharacters;
    [SerializeField] private InputField inputField;

    protected override void Start()
    {
        base.Start();
        boxType = BoxType.PRESS;
        inputField.characterLimit = maxCharacters;
        inputField.onValueChanged.AddListener(delegate { OnValueChange(inputField); });
    }

    public string GetInputValue()
    {
        return inputField.text.ToLowerInvariant();
    }

    public void OnValueChange(InputField inputField)
    {
        inputField.text = inputField.text.ToUpperInvariant();
    }

    public override bool Execute()
    {
        if (inputField.text.Trim().Length == 0) return false;

        return Input.GetKey(inputField.text.ToLowerInvariant());
    }
}