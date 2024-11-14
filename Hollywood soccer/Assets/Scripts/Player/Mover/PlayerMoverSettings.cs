using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoverSettings", menuName = "Game design/Player/Mover")]
public class PlayerMoverSettings : ScriptableObject
{
    [SerializeField] private float _strafeSpeed;

    public float StrafeMoveSpeed => _strafeSpeed;
}