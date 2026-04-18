using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject userMenu;
    public GameObject gameMenu;
    public GameObject saveMenu;
    public GameObject languageMenu;

    public void ShowMain()
    {
        mainMenu.SetActive(true);
        userMenu.SetActive(false);
        gameMenu.SetActive(false);
        saveMenu.SetActive(false);
    }

    public void ShowUsers()
    {
        mainMenu.SetActive(false);
        userMenu.SetActive(true);
        gameMenu.SetActive(false);
        saveMenu.SetActive(false);
    }

    public void ShowGame()
    {
        mainMenu.SetActive(false);
        userMenu.SetActive(false);
        gameMenu.SetActive(true);
        saveMenu.SetActive(false);
    }

    public void ShowSave()
    {
        mainMenu.SetActive(false);
        userMenu.SetActive(false);
        gameMenu.SetActive(false);
        saveMenu.SetActive(true);
    }
    public void OpenLanguageMenu()
    {
        mainMenu.SetActive(false);
        languageMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
