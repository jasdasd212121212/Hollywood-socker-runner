using UnityEditor;
using UnityEngine;

public class PlayerPrefsAdmin : EditorWindow
{
    private string _key;

    [MenuItem("PlayerPrefs/Reseter")]
    public static void Open()
    {
        GetWindow<PlayerPrefsAdmin>();
    }

    private void OnGUI()
    {
        _key = EditorGUILayout.TextField(_key);

        if (GUILayout.Button("Reset"))
        {
            if (PlayerPrefs.HasKey(_key) == true)
            {
                PlayerPrefs.DeleteKey(_key);
                Debug.Log("Reseted!");
            }
            else
            {
                Debug.LogWarning($"Key: {_key} unable to found");
            }
        }
    }
}