using Zenject;

public class RestartButtonView : ButtonViewBase
{
    [Inject] private LevelsLoader _levelsLoader;

    protected override void Clicked()
    {
        _levelsLoader.RestartLevel();
    }
}