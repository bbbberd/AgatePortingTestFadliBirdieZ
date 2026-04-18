using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    private Dictionary<string, string> localizedText;

    private string currentLanguage;   

    public static event Action OnLanguageChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        string savedLanguage = PlayerPrefs.GetString("language", "Bahasa");
        LoadLanguage(savedLanguage);
    }

    public void LoadLanguage(string language)
    {
        string path = Path.Combine(Application.streamingAssetsPath, language + ".json");

        if (!File.Exists(path))
        {
            //Debug.LogError("Localization file not found: " + path);
            return;
        }

        string json = File.ReadAllText(path);
        LocalizationData data = JsonUtility.FromJson<LocalizationData>(json);

        localizedText = new Dictionary<string, string>();

        foreach (LocalizationItem item in data.items)
        {
            localizedText[item.key] = item.value;
        }

        currentLanguage = language;

        OnLanguageChanged?.Invoke();
    }

    public string GetText(string key)
    {
        if (localizedText != null && localizedText.ContainsKey(key))
            return localizedText[key];

        return key;
    }
}