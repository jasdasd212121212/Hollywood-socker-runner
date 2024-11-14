using Zenject;

public class PlayButtonView : ButtonViewBase
{
    [Inject] private LevelsLoader _levelsLoader;

    protected override void Clicked()
    {
        _levelsLoader.LoadGame();      
    }
}