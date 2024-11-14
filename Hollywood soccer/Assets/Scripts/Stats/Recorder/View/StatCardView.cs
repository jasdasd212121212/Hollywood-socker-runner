using TMPro;
using UnityEngine;

public class StatCardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(int count)
    {
        _text.text = $"X{count}";
    }
}