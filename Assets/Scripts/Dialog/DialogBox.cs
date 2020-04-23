using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI textObj;
    public TextMeshProUGUI speakerObj;

    public DialogData dialog;

    public int dialogIdx = -1;

    private int lineIdx = 0;

    private float timer = 0;
    private float speed = 0.1f;
    private float baseSpeed = 0.1f;
    private float fastSpeed = 0.01f;

    public bool isLineCompleted = false;

    private string text = "";

    private void Start()
    {
        speakerObj.text = "";
        textObj.text = "";
        ChangeDialog();
        text = Localization.singleton.GetTranslation(dialog.lines[dialogIdx].text);
    }

    private void Update()
    {
        if (!isLineCompleted)
        {
            if (timer >= speed && lineIdx < text.Length - 1)
            {
                timer = 0;
                lineIdx += 1;
                textObj.text += text[lineIdx];
            }
            else if (lineIdx >= text.Length - 1)
            {
                isLineCompleted = true;
            }

            timer += Time.deltaTime;
        }
    }

    private void RestaureTextSpeed()
    {
        speed = baseSpeed;
    }

    private void SpeedupText()
    {
        speed = fastSpeed;
    }

    public bool DidFinish()
    {
        return dialogIdx >= dialog.lines.Length - 1;
    }

    public void ChangeDialog()
    {
        if (DidFinish())
        {
            TutoManager.singleton.NextStatus(dialog.nextState);
            return;
        }

        isLineCompleted = false;
        timer = 0;
        dialogIdx += 1;
        lineIdx = 0;
        speakerObj.text = Localization.singleton.GetTranslation(dialog.lines[dialogIdx].speaker) + ":";
        text = Localization.singleton.GetTranslation(dialog.lines[dialogIdx].text);
        textObj.text = text[0].ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isLineCompleted)
        {
            SpeedupText();
        }
        else if (dialog.ChangeDialogOnClick) { ChangeDialog(); }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RestaureTextSpeed();
    }
}