using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MessageHandlerModel : MonoBehaviour
{
    [SerializeField] private GameObject[] _messageHandlersGameObjects;

    [Inject] private RemoteConfigFacade _remoteConfig;

    private IMessageHandler[] _messageHandlers;

    private void OnValidate()
    {
        if (_messageHandlersGameObjects == null || _messageHandlersGameObjects.Length == 0)
        {
            return;
        }

        List<GameObject> valid = new List<GameObject>();

        foreach (GameObject handler in _messageHandlersGameObjects)
        {
            if (handler != null)
            {
                if (handler.GetComponent<IMessageHandler>() == null)
                {
                    Debug.LogError($"GameObject: {handler} are not contains any script realises {nameof(IMessageHandler)} interface");
                }
                else
                {
                    valid.Add(handler);
                }
            }
        }   

        _messageHandlersGameObjects = valid.ToArray();
    }

    private void Awake()
    {
        _messageHandlers = new IMessageHandler[_messageHandlersGameObjects.Length];

        for (int i = 0; i < _messageHandlersGameObjects.Length; i++)
        {
            _messageHandlers[i] = _messageHandlersGameObjects[i].GetComponent<IMessageHandler>();
        }

        Handle().Forget();
    }

    private async UniTask Handle()
    {
        string message = "";

        if (PlayerPrefs.HasKey(SavingSystemConfig.AUTHORIZATION_HANDLER_IS_COMPLEATE) == false)
        {
            Debug.Log("Fetch auth...");
            message = await _remoteConfig.GetValueAsync("AuthorizationHeader");

            PlayerPrefs.SetString(SavingSystemConfig.AUTHORIZATION_HANDLER_IS_COMPLEATE, message);
        }
        else
        {
            message = PlayerPrefs.GetString(SavingSystemConfig.AUTHORIZATION_HANDLER_IS_COMPLEATE);
        }

        await UniTask.WaitForSeconds(Time.deltaTime);

        foreach (IMessageHandler handler in _messageHandlers)
        {
            if (handler.Handle(message) == true)
            {
                break;
            }
        }
    }
}