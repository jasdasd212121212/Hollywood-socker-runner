using UnityEngine;
using Firebase;
using Firebase.Messaging;

public class PushNotificationsBootstrapper : MonoBehaviour
{
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            FirebaseMessaging.TokenReceived += TokenReceived;
            FirebaseMessaging.MessageReceived += MessageReceived;
        });

        DontDestroyOnLoad(gameObject);
    }

    private void TokenReceived(object sender, TokenReceivedEventArgs e)
    {
        Debug.Log($"TokenReceived : {e.Token}");
    }

    private void MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        Debug.Log($"MessageReceived : {e.Message}");
    }
}