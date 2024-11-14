using UnityEngine.SceneManagement;

public class LevelsLoader
{
    private LevelsLoaderSettings _settings;
    private ScoreCounterModel _scoreCounter;
    private StatsRecorderModel _statsRecorder;

    public LevelsLoader(LevelsLoaderSettings settings, ScoreCounterModel scoreCounter, StatsRecorderModel statsRecorderModel)
    {
        _settings = settings;
        _scoreCounter = scoreCounter;
        _statsRecorder = statsRecorderModel;
    }

    public void LoadMainMenu()
    {
        _statsRecorder.AddToHistory();
        _scoreCounter.Reset();

        SceneManager.LoadScene(_settings.MainMenuSceneIndex);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_settings.GameplaySceneIndex);
    }

    public void RestartLevel()
    {
        _statsRecorder.AddToHistory();
        _scoreCounter.Reset();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}