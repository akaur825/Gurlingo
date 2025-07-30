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
                    "<indent=180><b>Raag:</b> <i> A set of notes ascending and descending a scale that provokes a specific emotion. The purpose of a raag is to teach classical music techniques and provide a musical framework for Gurbani that helps provoke emotion.</i>\n\n" +
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
                    "<indent=180>https://youtu.be/iiUHl8fTn5Y?si=smegPS9pAaLQaBkl\n\n\n"

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
                    "<indent=180>https://youtu.be/Wzw2eQ1FN2A?si=wzrnDVza_AMseZoh\n\n\n"

                )
            },
            {
                (InfoType.Raag, 4),
                (
                    "Level Four",
                    "\n<align=center><b>Welcome to Level Four: Raag Basant!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Basant:</color></b>\n\n" +

                    "<indent=180><b>Raag Basant is the 25th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Bilaval Thaat — uses all Shudh notes.</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Audav–Sampooran Jaati — 5 notes in Aroh, 7 in Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Associated with Spring; no specific pehar — can be sung all day.</i>\n\n" +
                    "<indent=180><b>Raag Basant has NO Mishrat Raags.</b>\n\n" +
                    "<indent=180><b>Basant Ki Vaar</b> — a well-known bani is composed in Raag Basant.\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Ga Ma Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni Dha Pa Ma Ga Re Sa</i>\n" +
                    "<indent=180>Notice how all notes are Shudh!\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Sa (Shadaj)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Ma (Madhyam)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/LUoSCMa2I-E?si=Qo3d_NzBqzmNznEw\n\n\n"

                )
            },
            {
                (InfoType.Raag, 5),
                (
                    "Level Five",
                    "\n<align=center><b>Welcome to Level Five: Raag Kalyan!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Kalyan:</color></b>\n\n" +

                    "<indent=180><b>Raag Kalyan is the 29th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Kalyan Thaat — uses all Shudh notes, with vakrit Ma (Teevra Ma used creatively).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran Jaati — all 7 notes are used in both the Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Evening Raag — commonly sung between 6pm and 9pm.</i>\n\n" +
                    "<indent=180><b>Mishrat Raag:</b> <i>Kalyan Bhopali.</i>\n\n" +
                    "<indent=180><b>This Raag is very popular and is also known as Raag Yaman in Indian Classical music.</b>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Re Ga Ma (Teevra) Pa Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni Dha Pa Ma (Teevra) Ga Re Sa</i>\n" +
                    "<indent=180>Note: Vakrit Ma — Teevra Ma is used in a special way.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Ga (Gandhar)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Ni (Nishad)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/gnEX7tLlVJY?si=ukO48tQMbbFqZUNt\n\n\n"

                )
            },
            {
                (InfoType.Raag, 6),
                (
                    "Level Six",
                    "\n<align=center><b>Welcome to Level Six: Raag Maaroo!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Maaroo:</color></b>\n\n" +

                    "<indent=180><b>Raag Maaroo is the 21st Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Khamaaj Thaat — Ni is typically vakrit (used with variation).</i>\n\n" +
                    "<indent=180><b>Note Usage:</b> <i>Both forms of Ni, Dha, and Ma are used.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung between 12pm – 3pm.</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Shaudav–Sampooran — 6 notes in Aroh, 7 in Avroh.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>Maaroo Kafi and Maaroo Dakhni.</i>\n\n" +
                    "<indent=180><b>This Raag is sung during times of war and death but aims to uplift and inspire the spirit.</b>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Ga Ma Pa Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ ni Dha Pa, ma Pa dha Ni dha Pa, Ma Ga Re Sa</i>\n" +
                    "<indent=180>Note the unique use of both shudh and vakrit forms.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Ga (Gandhar)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Ni (Nishad)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/SHCeMRhF5Aw?si=kFdKT7sGm983r3TB\n\n\n"

                )
            },
            {
                (InfoType.Raag, 7),
                (
                    "Level Seven",
                    "\n<align=center><b>Welcome to Level Seven: Shree Raag!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Shree Raag:</color></b>\n\n" +

                    "<indent=180><b>Raag Shree is the 1st Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Purvi Thaat — Ma, Re, and Dha are vakrit (used with variation).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Audav–Sampooran — 5 notes in Aroh, 7 in Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung between 6pm – 9pm.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>None — Shree stands alone in its structure.</i>\n\n" +
                    "<indent=180><b>This Raag provokes a deep sense of separation and longing — it is primarily a serious and somber raag.</b>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Re (vakrit) Ma Pa Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni Dha Pa Ma Ga Re Sa</i>\n" +
                    "<indent=180>Notice the vakrit use of Ma, Re, and Dha in both ascent and descent.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Re (Rishabh)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Pa (Pancham)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/R8o5ra6E_n0?si=3iNzUIIvRLm0FPrd\n\n\n"

                )
            },
                        {
                (InfoType.Raag, 8),
                (
                    "Level Eight",
                    "\n<align=center><b>Welcome to Level Eight: Raag Todi!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Todi:</color></b>\n\n" +

                    "<indent=180><b>Raag Todi is the 12th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Todi Thaat — Ma, Re, Dha, and Ga are typically vakrit (used in ornamented forms).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran — all 7 notes are used in both Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung between 12pm – 3pm.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>None — Todi is a pure raag.</i>\n\n" +
                    "<indent=180><b>This Raag is considered very serious and is performed with deep emotional intensity.</b>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa re ga ma, Pa, ma dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni dha, Pa, ma dha ma ga re Sa</i>\n" +
                    "<indent=180>Vakrit notes create a deeply expressive and ornamented character.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Dha (Dhaivat)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Ga (Gandhar)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/bvRY-CsPvyc?si=R47zriNo6VqliXhM\n\n\n"

                )
            },
            {
                (InfoType.Raag, 9),
                (
                    "Level Nine",
                    "\n<align=center><b>Welcome to Level Nine: Raag Sarang!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Sarang:</color></b>\n\n" +

                    "<indent=180><b>Raag Sarang is the 26th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Kafi Thaat — Ga and Ni are typically vakrit (used with variation).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Audav — 5 notes in both Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Note Usage:</b> <i>Both forms of Ni are used.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung between 12pm – 3pm.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>None — Sarang is a standalone raag.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa Re Ma Pa Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ ni Pa Ma Re Sa</i>\n" +
                    "<indent=180>Vakrit notes and audav structure give Sarang its unique melodic feel.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Re (Rishabh)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Pa (Pancham)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/0w0Yy7OOD0o?si=8CZNKVtM6GcHEaer\n\n\n"

                )
            },
            {
                (InfoType.Raag, 10),
                (
                    "Level Ten",
                    "\n<align=center><b>Welcome to Level Ten: Raag Malhar!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Malhar:</color></b>\n\n" +

                    "<indent=180><b>Raag Malhar is the 27th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Khamaaj Thaat — Ni is typically vakrit (used ornamentally or with variation).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran — all 7 notes are used in both Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung anytime during the Rainy / Savan season.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>None — Malhar is a standalone, classical monsoon raag.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa, Re Ga Ma, Re Pa ni Dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Dha ni Pa, Ga Ma Re Sa</i>\n" +
                    "<indent=180>Malhar features fluid phrases that evoke the sound and mood of rain.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Ma (Madhyam)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Sa (Shadaj)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/n6G6IomIZFM?si=eW0nYZGP-j97RlbO\n\n\n"

                )
            },
            {
                (InfoType.Raag, 11),
                (
                    "Level Eleven",
                    "\n<align=center><b>Welcome to Level Eleven: Raag Bhairo!</b></align>\n\n" +

                    "<indent=135><b><color=#F5A40A>About Raag Bhairo:</color></b>\n\n" +

                    "<indent=180><b>Raag Bhairo is the 24th Shudh Raag in Sri Guru Granth Sahib Ji.</b>\n\n" +
                    "<indent=180><b>Thaat:</b> <i>Bhairav Thaat — Re, Ga, Dha, and Ni are typically vakrit (used ornamentally or with variation).</i>\n\n" +
                    "<indent=180><b>Jaati:</b> <i>Sampooran — all 7 notes are used in both Aroh and Avroh.</i>\n\n" +
                    "<indent=180><b>Time:</b> <i>Sung between 6am – 9am — a popular early morning raag.</i>\n\n" +
                    "<indent=180><b>Mishrat Raags:</b> <i>None — Bhairo is a distinct and complete raag.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Aroh & Avroh:</color></b>\n\n" +
                    "<indent=180><b>Aroh:</b> <i>Sa re Ga Ma Pa dha Ni Sa’</i>\n" +
                    "<indent=180><b>Avroh:</b> <i>Sa’ Ni dha Pa Ma Ga re Sa</i>\n" +
                    "<indent=180>The vakrit swars give Bhairo a deep, meditative character.\n\n" +

                    "<indent=135><b><color=#F5A40A>Vadi & Samvadi:</color></b>\n\n" +
                    "<indent=180><b>Vadi:</b> <i>Dha (Dhaivat)</i>\n" +
                    "<indent=180><b>Samvadi:</b> <i>Re (Rishabh)</i>\n" +
                    "<indent=180>Remember: Vadi = Most used note and Samvadi = 2nd most used.</i>\n\n" +

                    "<indent=135><b><color=#F5A40A>Example Shabad:</color></b>\n\n" +
                    "<indent=180>https://youtu.be/r_ev2D481uw?si=hqlBYzt5HcO8P7_w\n\n\n"

                )
            },
            {
                (InfoType.Sur, 1),
                (
                    "Introduction to Sur",
                    "\n<align=center><b>Welcome to the first level of Sur Training! In this level, you will begin learning sur-related terminology and the first sur, Sa.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Useful Terminology:</color></b>\n\n" +
                    "<indent=180><b>Sur:</b> <i> A musical note.</i>\n\n" +
                    "<indent=180><b>Vakrit Sur:</b> <i> Variation of a Sur.</i>\n\n" +
                    "<indent=180><b>Komal Sur:</b> <i> Soft or flatter variation of a Sur - re, ga, dha, ni.</i>\n\n" +
                    "<indent=180><b>Teevar Sur:</b> <i> Sharper variation of a Sur - ma.</i>\n\n" +
                    "<indent=180><b>Achala Sur:</b> <i> Sur that is fixed in place; It has no Vakrit form - Sa, Pa.</i>\n\n" +
                    "<indent=180><b>Saptak:</b> <i> There are three Saptaks (Octaves) in Gurmat Sangeet - Mandar (low), Madhyam (medium), and Taar (high). Each Saptak has 12 notes (including Vakrit Surs).</i>\n\n" +
                    "<indent=180><b>Shadaj:</b> <i> The proper and full name of Sa.</i>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Note:</b><i> Shadaj is an Achala Sur.</i>\n\n"
                )
            },
            {
                (InfoType.Sur, 2),
                (
                    "Level Two",
                    "\n<align=center><b>In this level we will introduce a new note, Re, or Rishab.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Komal:</b>\n\n"
                )
            },
            {
                (InfoType.Sur, 3),
                (
                    "Level Three",
                    "\n<align=center><b>In this level we will introduce a new note, Ga, or Gandhar.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Komal:</b>\n\n"
                )
            },
            {
                (InfoType.Sur, 4),
                (
                    "Level Four",
                    "\n<align=center><b>In this level we will introduce a new note, Ma, or Madhyam.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Teevar:</b>\n\n"
                )
            },
            {
                (InfoType.Sur, 5),
                (
                    "Level Five",
                    "\n<align=center><b>In this level we will introduce a new note, Pa, or Pancham.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Note:</b><i> Pancham is an Achala Sur, meaning it has no Vakrit form.</i>\n\n"
                )
            },
            {
                (InfoType.Sur, 6),
                (
                    "Level Six",
                    "\n<align=center><b>In this level we will introduce a new note, Dha, or Dhaivat.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Komal:</b>\n\n" 
                )
            },
            {
                (InfoType.Sur, 7),
                (
                    "Level Seven",
                    "\n<align=center><b>In this level we will introduce the final note in a Saptak, Ni, or Nishad.</b></align>\n\n" +
                    "<indent=135><b><color=#F5A40A>Click below to hear this note!</color></b>\n\n" +
                    "<indent=180><b>Shudh:</b>\n\n" +
                    "<indent=180><b>Komal:</b>\n\n" 
                )
            }
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