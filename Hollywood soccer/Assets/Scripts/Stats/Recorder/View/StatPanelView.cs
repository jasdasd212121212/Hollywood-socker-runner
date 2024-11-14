using UnityEngine;
using Zenject;

public class StatPanelView : MonoBehaviour
{
    [SerializeField] private StatCardView _cardViewPrefab;

    [Space]

    [SerializeField] private RectTransform _content;

    [Space]

    [SerializeField] private Transform _topText;
    [SerializeField] private Transform _lastText;

    [Space]

    [SerializeField][Min(1)] private int _topCount = 3;

    [Inject] private StatsRecorderModel _statsRecorderModel;

    private MonoFactory<StatCardView> _viewsFactory;

    private void Start()
    {
        _viewsFactory = new MonoFactory<StatCardView>(_cardViewPrefab, _content);

        Display();
    }

    private void Display()
    {
        _topText.SetParent(transform);
        _lastText.SetParent(transform);

        int[] top = _statsRecorderModel.GetTop(_topCount);

        SpawnList(_topText, top);
        SpawnList(_lastText, _statsRecorderModel.GetWithExclude(_topCount));
    }

    private void SpawnList(Transform text, int[] list)
    {
        text.SetParent(_content);

        foreach (int item in list)
        {
            _viewsFactory.Create().Initialize(item);
        }
    }
}