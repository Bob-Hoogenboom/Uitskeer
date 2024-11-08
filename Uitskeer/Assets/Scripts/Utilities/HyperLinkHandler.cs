using UnityEngine;
using TMPro;

public class HyperlinkHandler : MonoBehaviour
{
    private TMP_TextEventHandler textEventHandler;

    private void Awake()
    {
        textEventHandler = GetComponent<TMP_TextEventHandler>();
        if (textEventHandler != null)
        {
            textEventHandler.onLinkSelection.AddListener(OnLinkClicked);
        }
    }

    private void OnDestroy()
    {
        if (textEventHandler != null)
        {
            textEventHandler.onLinkSelection.RemoveListener(OnLinkClicked);
        }
    }

    private void OnLinkClicked(string linkID, string linkText, int linkIndex)
    {
        Debug.Log("Link clicked: " + linkID);

        // Open the link in the default web browser
        Application.OpenURL(linkID);
    }
}