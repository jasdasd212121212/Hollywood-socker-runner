using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings", menuName = "Game design/Collectable/Ball")]
public class BallSettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _collectCost = 1;

    public int CollectCost => _collectCost;
}