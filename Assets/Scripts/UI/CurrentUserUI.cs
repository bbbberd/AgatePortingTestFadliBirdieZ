using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentUserUI : MonoBehaviour
{
    [SerializeField] private TMP_Text userText;

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
        if (userText == null)
            return;

        if (LocalizationManager.Instance == null)
            return;

        if (UserManager.Instance == null)
            return;

        string userWord = LocalizationManager.Instance.GetText("current_user");
        string noneWord = LocalizationManager.Instance.GetText("no_user");

        string user = UserManager.Instance.CurrentUser;

        userText.text = string.IsNullOrEmpty(user)
            ? $"{userWord} : {noneWord}"
            : $"{userWord} : {user}";
    }
}