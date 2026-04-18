using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    public string key;
    private TMP_Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        UpdateText();
        LocalizationManager.OnLanguageChanged += UpdateText;
    }

    void OnDisable()
    {
        LocalizationManager.OnLanguageChanged -= UpdateText;
    }

    void UpdateText()
    {
        if (LocalizationManager.Instance != null)
        {
            textComponent.text = LocalizationManager.Instance.GetText(key);
        }
    }
}