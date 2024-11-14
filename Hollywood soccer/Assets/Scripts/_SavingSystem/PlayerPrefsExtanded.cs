using UnityEngine;

public static class PlayerPrefsExtanded
{
    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value == true ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}