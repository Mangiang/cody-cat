using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationProxyUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();

    private void Start()
    {
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].text = Localization.singleton.GetTranslation(textList[i].text);
        }
    }
}