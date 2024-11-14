using UnityEngine;
using Zenject;

public class EmptyMessageHandler : MonoBehaviour, IMessageHandler
{
    [Inject] private LevelsLoader _loader;

    public bool Handle(string message)
    {
        if (message.Trim() == string.Empty || string.IsNullOrEmpty(message) || message == "")
        {
            _loader.LoadMainMenu();
            return true;
        }

        return false;
    }
}