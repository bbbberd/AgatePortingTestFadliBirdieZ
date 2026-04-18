using System.Collections;
using TMPro;
using UnityEngine;

public class SaveMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] slotTexts;

    void OnEnable()
    {
        LocalizationManager.OnLanguageChanged += RefreshSlots;
        StartCoroutine(DelayedRefresh());
    }

    void OnDisable()
    {
        LocalizationManager.OnLanguageChanged -= RefreshSlots;
    }

    IEnumerator DelayedRefresh()
    {
        yield return null;
        RefreshSlots();
    }

    public void RefreshSlots()
    {
        if (SaveManager.Instance == null) return;

        for (int i = 0; i < slotTexts.Length; i++)
        {
            string preview = SaveManager.Instance.GetSlotPreview(i);
            string slotWord = LocalizationManager.Instance.GetText("slot");

            slotTexts[i].text = $"{slotWord} {i + 1} : {preview}";
        }
    }

    public void SaveSlot(int slot)
    {
        bool success = SaveManager.Instance.Save(slot);

        //if (success)
        //    Debug.Log("Saved slot " + slot);

        RefreshSlots();
    }

    public void LoadSlot(int slot)
    {
        bool success = SaveManager.Instance.Load(slot);

        //if (success)
        //    Debug.Log("Loaded slot " + slot);

        RefreshSlots();
    }
}