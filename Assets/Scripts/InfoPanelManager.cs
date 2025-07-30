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
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 2),
                (
                    "Level Two",
                    "\n<align=center><b>Welcome to Level Two: Raag Bilaval!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Bilaval:</color></b>\n\n" +

                    "<indent=180><b>Raag Bilaval is the 16th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Bilaval Thaat — uses all Shudh notes.</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran Jaati — all 7 notes are used in both the Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>2nd Pehar of the day (9am – 12pm).</i>\n\n" +
                    "<indent=180><b>Raag Bilaval is a very popular raag and is often one of the first raags taught to those learning Gurmat Sangeet, due to its usage of all shudh notes.</b>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>Bilaval Mangal and Bilaval Dakhni.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Re Ga Ma Pa Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni Dha Pa Ma Ga Re Sa</i>\n" +
                    "<indent=180>Notice how all notes are Shudh!\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Pa (Pancham)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Sa (Shadaj)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Mood:</color></b>\n\n" +
                    "<indent=180><i>Raag Bilaval is a very happy and joyful raag.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/ayz3IjAXlXw?si=Ou6FqX0uelA8rk_4\n"
                )
            },
            {
                (InfoType.Raag, 3),
                (
                    "Level Three",
                    "\n<align=center><b>Welcome to Level Three: Raag Gond!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Gond:</color></b>\n\n" +

                    "<indent=180><b>Raag Gond is the 17th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Bilaval Thaat — uses all Shudh notes.</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran Jaati — all 7 notes are used in both the Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>2nd Pehar of the day (9am – 12pm).</i>\n\n" +
                    "<indent=180><b>Raag Gond is an uncommon raag in Gurmat Sangeet, unlike Raag Bilaval.</b>\n\n" +
                    "<indent=180><b>Mishrat Raag:</b> <i>Bilaval Gond.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Re Ga Ma Pa Dha Ni Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni Dha Ni Pa Ma Ga Re Sa</i>\n" +
                    "<indent=180>Notice how all notes are Shudh!\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Ma (Madhyam)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Sa (Shadaj)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Mood:</color></b>\n\n" +
                    "<indent=180><i>Gond’s mood is not widely documented, but it is often considered meditative and introspective due to its uncommon usage.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/WR2p3yANJKE?si=L9vrwRrDd1L6LDo-\n"
                )
            },
            {
                (InfoType.Raag, 4),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 5),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 6),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 7),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
                        {
                (InfoType.Raag, 8),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 9),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 10),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Raag, 11),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
                        {
                (InfoType.Sur, 1),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 2),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 3),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 4),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 5),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 6),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 7),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 8),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 9),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 10),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 11),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
            {
                (InfoType.Sur, 12),
                (
                    "Introduction to Raags",
                    "\n<align=center><b>Welcome to the first level of Raag Training! In this level, we will go over some of the fundamental terms of Gurmat Sangeet.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion..</i>\n\n" +
                    "<indent=180><b>Shudh Raag:</b> <i> A raag without the influence of other raags. There are 31 of them in Sri Guru Granth Sahib Ji.</i>\n\n" +
                    "<indent=180><b>Aroh:</b> <i> The set of notes that ascend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Avroh:</b> <i> The set of notes that descend the scale of a raag.</i>\n\n" +
                    "<indent=180><b>Vadi:</b> <i> The most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Samvadi:</b> <i> The second most used sur in a raag.</i>\n\n" +
                    "<indent=180><b>Varjit Surs:</b> <i> Notes that cannot be used in a raag.</i>\n\n" +
                    "<indent=180><b>Mukh Ang:</b> <i> A set of notes that can help define a raag.</i>"
                )
            },
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
