using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public abstract class ButtonViewBase : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        Clicked();
    }

    protected abstract void Clicked();
}