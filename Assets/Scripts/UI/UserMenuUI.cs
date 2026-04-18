using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_Text userListText;

    void OnEnable()
    {
        LocalizationManager.OnLanguageChanged += RefreshUserList;
        RefreshUserList();
    }
    void OnDisable()
    {
        LocalizationManager.OnLanguageChanged -= RefreshUserList;
    }

    public void CreateUser()
    {
        string username = usernameInput.text;

        bool success = UserManager.Instance.CreateUser(username);

        //if (success)
        //    Debug.Log("User created");
        //else
        //    Debug.LogWarning("Failed to create user");

        RefreshUserList();
    }

    public void SelectUser()
    {
        string username = usernameInput.text;

        bool success = UserManager.Instance.SelectUser(username);

        //if (success)
        //    Debug.Log("User selected: " + username);
        //else
        //    Debug.LogWarning("User does not exist");
    }

    public void DeleteUser()
    {
        string username = usernameInput.text;

        bool success = UserManager.Instance.DeleteUser(username);

        //if (success)
        //    Debug.Log("User deleted");
        //else
        //    Debug.LogWarning("Delete failed");

        RefreshUserList();
    }

    void RefreshUserList()
    {
        string[] users = UserManager.Instance.GetAllUsers();

        if (users.Length == 0)
        {
            userListText.text = LocalizationManager.Instance.GetText("no_users_found");
            return;
        }

        userListText.text = LocalizationManager.Instance.GetText("existing_users") + "\n";

        foreach (string user in users)
        {
            userListText.text += "- " + user + "\n";
        }
    }
}
