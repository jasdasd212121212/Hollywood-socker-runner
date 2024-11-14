using UnityEngine;

public class AdditionalPagesWebViewButtonHelper : MonoBehaviour
{
    [SerializeField] private WebViewBootsrapper _webViewModel;
    
    public void OpenUrl(string url)
    {
        _webViewModel.Open(url, true);
    }
}