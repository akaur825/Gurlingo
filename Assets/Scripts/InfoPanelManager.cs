using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoPanelManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI bodyText;
    public Button closeButton;

    private int infoLevel = 1;


    // Wrapper methods for Unity UI
    public void ShowRaagLevel1() => ShowInfo(InfoType.Raag, 1);
    public void ShowRaagLevel2() => ShowInfo(InfoType.Raag, 2);
    public void ShowRaagLevel3() => ShowInfo(InfoType.Raag, 3);
    public void ShowRaagLevel4() => ShowInfo(InfoType.Raag, 4);
    public void ShowRaagLevel5() => ShowInfo(InfoType.Raag, 5);
    public void ShowRaagLevel6() => ShowInfo(InfoType.Raag, 6);
    public void ShowRaagLevel7() => ShowInfo(InfoType.Raag, 7);
    public void ShowRaagLevel8() => ShowInfo(InfoType.Raag, 8);
    public void ShowRaagLevel9() => ShowInfo(InfoType.Raag, 9);
    public void ShowRaagLevel10() => ShowInfo(InfoType.Raag, 10);
    public void ShowRaagLevel11() => ShowInfo(InfoType.Raag, 11);
    public void ShowSurLevel1() => ShowInfo(InfoType.Sur, 1);
    public void ShowSurLevel2() => ShowInfo(InfoType.Sur, 2);
    public void ShowSurLevel3() => ShowInfo(InfoType.Sur, 3);
    public void ShowSurLevel4() => ShowInfo(InfoType.Sur, 4);
    public void ShowSurLevel5() => ShowInfo(InfoType.Sur, 5);
    public void ShowSurLevel6() => ShowInfo(InfoType.Sur, 6);
    public void ShowSurLevel7() => ShowInfo(InfoType.Sur, 7);
    public void ShowSurLevel8() => ShowInfo(InfoType.Sur, 8);
    public void ShowSurLevel9() => ShowInfo(InfoType.Sur, 9);
    public void ShowSurLevel10() => ShowInfo(InfoType.Sur, 10);
    public void ShowSurLevel11() => ShowInfo(InfoType.Sur, 11);
    public void ShowSurLevel12() => ShowInfo(InfoType.Sur, 12);
    // Add more wrappers as needed



    public enum InfoType
    {
        Raag,
        Sur
    }

    [Header("Info Settings")]
    public InfoType infoType = InfoType.Raag;

    private Dictionary<(InfoType, int), (string title, string body)> infoContent;

    void Start()
    {
        closeButton.onClick.AddListener(HidePanel);
        infoPanel.SetActive(false);
        LoadInfoContent();
    }

    void LoadInfoContent()
    {
        infoContent = new Dictionary<(InfoType, int), (string title, string body)>
        {
            {
                (InfoType.Raag, 1),
                (
                    "Introduction to Raags",
                    "<b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b>\n\n" +
                    "<indent=30><b><color=#F5A40A>Useful Terminology:</color></b>\n" +
                    "<indent=50><b>Raag:</b> <i>A scale that provokes emotion...</i>\n\n" +
                    "<indent=50><b>Shudh Raag:</b> <i>A pure raag found in SGGS Ji...</i>\n\n" +
                    "<indent=50><b>Aroh:</b> <i>Ascending notes of a raag.</i>\n\n" +
                    "<indent=50><b>Avroh:</b> <i>Descending notes of a raag.</i>\n\n" +
                    "<indent=50><b>Vadi:</b> <i>Most emphasized note.</i>\n\n" +
                    "<indent=50><b>Samvadi:</b> <i>Second most emphasized note.</i>\n\n" +
                    "<indent=50><b>Varjit Surs:</b> <i>Notes not allowed in a raag.</i>\n\n" +
                    "<indent=50><b>Mukh Ang:</b> <i>Signature phrase defining a raag.</i>"
                )
            },
            // Add more like (InfoType.Raag, 2), (InfoType.Sur, 1), etc.
        };
    }

    public void ShowInfo(InfoType type, int level)
    {
        infoType = type;
        infoLevel = level;

        if (infoContent.TryGetValue((infoType, infoLevel), out var content))
        {
            infoPanel.SetActive(true);
            titleText.text = content.title;
            bodyText.text = content.body;
        }
        else
        {
            Debug.LogWarning($"Info not found for {type} Level {level}");
            titleText.text = "Information";
            bodyText.text = "No info available for this level.";
            infoPanel.SetActive(true);
        }
    }

    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }
}
