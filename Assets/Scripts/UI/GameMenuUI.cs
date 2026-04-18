using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuUI : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text goldText;

    void OnEnable()
    {
        LocalizationManager.OnLanguageChanged += UpdateUI;
        UpdateUI();
    }

    void OnDisable()
    {
        LocalizationManager.OnLanguageChanged -= UpdateUI;
    }

    void UpdateUI()
    {
        if (LocalizationManager.Instance == null)
            return;

        if (UserManager.Instance == null)
            return;

        if (string.IsNullOrEmpty(UserManager.Instance.CurrentUser))
            return;

        levelText.text = LocalizationManager.Instance.GetText("level") + ": " + SaveManager.CurrentData.Level;
        goldText.text = LocalizationManager.Instance.GetText("gold") + ": " + SaveManager.CurrentData.Gold;
    }

    public void AddGold()
    {
        SaveManager.CurrentData.Gold += 100;
        UpdateUI();
    }

    public void AddLevel()
    {
        SaveManager.CurrentData.Level += 1;
        UpdateUI();
    }
}