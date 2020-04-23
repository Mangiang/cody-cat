using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationProxy : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> textList = new List<TextMeshPro>();

    private void Start()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].text = Localization.singleton.GetTranslation(textList[i].text);
        }
    }
}