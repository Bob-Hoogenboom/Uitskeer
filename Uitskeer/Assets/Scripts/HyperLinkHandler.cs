using UnityEngine;
using TMPro;

public class HyperLinkHandler : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, null);

            // If a link was clicked
            if (linkIndex != -1)
            {
                // Get the link info
                TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];

                // Open the link's ID as a URL
                Application.OpenURL(linkInfo.GetLinkID());
            }
        }
    }
}