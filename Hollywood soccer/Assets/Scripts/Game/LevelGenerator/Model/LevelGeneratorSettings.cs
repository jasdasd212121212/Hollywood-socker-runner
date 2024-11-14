using UnityEngine;

[CreateAssetMenu(fileName = "levelGenratorSettings", menuName = "Game design/Level/GeneratorSettings")]
public class LevelGeneratorSettings : ScriptableObject
{
    [SerializeField][Range(1, 10)] private int _minEnemyesPerLine;
    [SerializeField][Range(2, 10)] private int _maxEnemyesPerLine;

    [Space]

    [SerializeField][Range(1, 10)] private int _minCollectablesPerLine;
    [SerializeField][Range(2, 10)] private int _maxCollectablesPerLine;

    [Space]

    [SerializeField][Min(0.01f)] private float _offset = 3f;

    [Space]

    [SerializeField][Min(1)] private int _collectablesCount = 1;

    public int MinEnemyesPerLine => _minEnemyesPerLine;
    public int MaxEnemyesPerLine => _maxEnemyesPerLine;

    public int MinCollectablesPerLine => _minCollectablesPerLine;
    public int MaxCollectablesPerLine => _maxCollectablesPerLine;

    public float Offset => _offset;

    public int CollectablesCount => _collectablesCount;

    private void OnValidate()
    {
        _minCollectablesPerLine = Mathf.Clamp(_minCollectablesPerLine, 1, _maxCollectablesPerLine);
        _minEnemyesPerLine = Mathf.Clamp(_minEnemyesPerLine, 1, _maxEnemyesPerLine);
    }
}