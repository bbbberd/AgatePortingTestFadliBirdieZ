using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public static GameData CurrentData = new GameData();

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

    string GetUserFolder()
    {
        return Path.Combine(
            Application.persistentDataPath,
            "Users",
            UserManager.Instance.CurrentUser
        );
    }

    public bool Save(int slot)
    {
        if (UserManager.Instance.CurrentUser == null)
            return false;

        string folder = GetUserFolder();

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string file = Path.Combine(folder, $"slot{slot}.dat");

        try
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                writer.Write(CurrentData.Level);
                writer.Write(CurrentData.Gold);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Load(int slot)
    {
        if (UserManager.Instance.CurrentUser == null)
            return false;

        string file = Path.Combine(GetUserFolder(), $"slot{slot}.dat");

        if (!File.Exists(file))
            return false;

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                CurrentData.Level = reader.ReadInt32();
                CurrentData.Gold = reader.ReadInt32();
            }

            //Debug.Log("Game Loaded");
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetSlotPreview(int slot)
    {
        if (UserManager.Instance == null || string.IsNullOrEmpty(UserManager.Instance.CurrentUser))
        {
            return LocalizationManager.Instance.GetText("empty");
        }

        string file = Path.Combine(
            Application.persistentDataPath,
            "Users",
            UserManager.Instance.CurrentUser,
            $"slot{slot}.dat"
        );

        if (!File.Exists(file))
            return LocalizationManager.Instance.GetText("empty");

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int level = reader.ReadInt32();
                int gold = reader.ReadInt32();

                string levelWord = LocalizationManager.Instance.GetText("level");
                string goldWord = LocalizationManager.Instance.GetText("gold");

                return $"{levelWord} {level} | {goldWord} {gold}";
            }
        }
        catch
        {
            return LocalizationManager.Instance.GetText("corrupted");
        }
    }
}