using Zenject;

public class ExitToMainMenyButtonView : ButtonViewBase
{
    [Inject] private LevelsLoader _levelsLoader;
    [Inject] private StatsRecorderModel _statsrecorder;

    protected override void Clicked()
    {
        _levelsLoader.LoadMainMenu();
    }
}