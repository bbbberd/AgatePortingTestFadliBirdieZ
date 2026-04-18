using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

    public string CurrentUser;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    string GetUsersPath()
    {
        return Path.Combine(Application.persistentDataPath, "Users");
    }

    public bool CreateUser(string username)
    {
        if (string.IsNullOrEmpty(username))
            return false;

        string path = Path.Combine(GetUsersPath(), username);

        if (Directory.Exists(path))
            return false;

        Directory.CreateDirectory(path);

        return true;
    }

    public bool SelectUser(string username)
    {
        string path = Path.Combine(GetUsersPath(), username);

        if (!Directory.Exists(path))
            return false;

        CurrentUser = username;
        SaveManager.CurrentData = new GameData();
        //Debug.Log("Current user: " + username);
        return true;
    }

    public bool DeleteUser(string username)
    {
        string path = Path.Combine(GetUsersPath(), username);

        if (!Directory.Exists(path))
            return false;

        Directory.Delete(path, true);

        return true;
    }

    public string[] GetAllUsers()
    {
        string path = GetUsersPath();

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string[] dirs = Directory.GetDirectories(path);

        for (int i = 0; i < dirs.Length; i++)
            dirs[i] = Path.GetFileName(dirs[i]);

        return dirs;
    }
}