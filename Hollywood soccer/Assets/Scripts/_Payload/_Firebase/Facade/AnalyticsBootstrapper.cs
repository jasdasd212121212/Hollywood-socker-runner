using Firebase.Analytics;
using UnityEngine;

public class AnalyticsBootstrapper : MonoBehaviour
{
    private void Start()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        DontDestroyOnLoad(gameObject);
    }
}