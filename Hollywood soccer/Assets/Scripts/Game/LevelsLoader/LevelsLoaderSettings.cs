using UnityEngine;

[CreateAssetMenu(fileName = "LevelsLoaderSettings", menuName = "Game design/Level/LoaderSettings")]
public class LevelsLoaderSettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _gameplaySceneIndex = 1;
    [SerializeField][Min(0)] private int _mainMenuSceneIndex = 0;

    public int GameplaySceneIndex => _gameplaySceneIndex;
    public int MainMenuSceneIndex => _mainMenuSceneIndex;
}