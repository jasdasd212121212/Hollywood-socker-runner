using UnityEngine;

public class PlayloadMessageHandler : MonoBehaviour, IMessageHandler
{
    [SerializeField] private WebViewBootsrapper _webView;

    public bool Handle(string message)
    {
        _webView.Open(message, false);

        return false;
    }
}