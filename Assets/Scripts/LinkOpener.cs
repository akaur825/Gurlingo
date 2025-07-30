using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class LinkOpener : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame && textMeshPro != null)
        {
            Vector2 mousePosition = Pointer.current.position.ReadValue();
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, mousePosition, Camera.main);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
                string url = linkInfo.GetLinkID();
                Application.OpenURL(url);
            }
        }
    }
}
