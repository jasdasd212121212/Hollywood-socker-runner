using UnityEngine;

public class WebViewBootsrapper : MonoBehaviour
{
    private UniWebView _webView;

    public void Open(string url, bool useBackButton)
    {
        _webView = new GameObject(url).AddComponent<UniWebView>();

        _webView.Frame = new Rect(0f, 0f, Screen.width, Screen.height);

        if (useBackButton == true)
        {
            _webView.EmbeddedToolbar.Show();
        }

        _webView.Load(url);
        _webView.Show();
    }

    public void Close()
    {
        if (_webView != null)
        {
            Destroy(_webView.gameObject);
        }
        else
        {
            Debug.LogWarning("Can`t close web view because web view are not opened!");
        }
    }
}