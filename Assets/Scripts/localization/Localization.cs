using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public static Localization singleton;
    private TextAsset languagesAsset;
    private string languagesPath = "lang";

    private List<Language> languages = new List<Language>();

    private Language currentLanguage;

    public string defaultLanguage;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;

        languagesAsset = Resources.Load(languagesPath + "/languages") as TextAsset;
        LanguagesList languagesList = JsonUtility.FromJson<LanguagesList>(languagesAsset.text);
        if (languagesList == null)
        {
            Debug.LogError("Could not read the languages json");
        }


        foreach (string lang in languagesList.langList)
        {
            TextAsset langAsset = Resources.Load(languagesPath + "/" + lang) as TextAsset;
            Language language = JsonUtility.FromJson<Language>(langAsset.text);
            if (language != null)
            {
                languages.Add(language);
            }
        }

        Language defaultLang = languages.Find(lang => lang.shortName == defaultLanguage);
        if (defaultLang != null)
        {
            currentLanguage = defaultLang;
        }
    }

    public string GetTranslation(string key)
    {
        if (currentLanguage == null) { Debug.LogError("No localization set"); return null; }

        return currentLanguage.values.Find(entry => entry.key == key).value;
    }
}