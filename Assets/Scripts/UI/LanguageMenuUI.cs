using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageMenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject languageMenuPanel;

    public void SetEnglish()
    {
        LocalizationManager.Instance.LoadLanguage("English");
        PlayerPrefs.SetString("language", "English");
    }

    public void SetBahasa()
    {
        LocalizationManager.Instance.LoadLanguage("Bahasa");
        PlayerPrefs.SetString("language", "Bahasa");
    }

    public void SetRussian()
    {
        LocalizationManager.Instance.LoadLanguage("Russian");
        PlayerPrefs.SetString("language", "Russian");
    }

    public void SetJapanese()
    {
        LocalizationManager.Instance.LoadLanguage("Japanese");
        PlayerPrefs.SetString("language", "Japanese");
    }

    public void SetChinese()
    {
        LocalizationManager.Instance.LoadLanguage("Chinese");
        PlayerPrefs.SetString("language", "Chinese");
    }

    public void BackToMainMenu()
    {
        languageMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}