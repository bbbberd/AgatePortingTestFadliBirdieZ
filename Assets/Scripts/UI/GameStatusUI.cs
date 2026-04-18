using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatusUI : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text goldText;

    void OnEnable()
    {
        if (LocalizationManager.Instance != null)
            LocalizationManager.OnLanguageChanged += Refresh;

        Refresh();
    }

    void OnDisable()
    {
        if (LocalizationManager.Instance != null)
            LocalizationManager.OnLanguageChanged -= Refresh;
    }

    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        
        if (levelText == null || goldText == null)
            return;

        if (LocalizationManager.Instance == null)
            return;

        if (SaveManager.CurrentData == null)
            return;

        string levelWord = LocalizationManager.Instance.GetText("level");
        string goldWord = LocalizationManager.Instance.GetText("gold");

        levelText.text = $"{levelWord} : {SaveManager.CurrentData.Level}";
        goldText.text = $"{goldWord} : {SaveManager.CurrentData.Gold}";
    }
}
