using System.IO;
using UnityEngine;

public class JsonSavingSystem : ISavingSystem
{
    public bool HasKey(string key)
    {
        return File.Exists(GetPatch(key));
    }

    public T Load<T>(string key)
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(GetPatch(key)));
    }

    public void Save<T>(string key, T data)
    {
        File.WriteAllText(GetPatch(key), JsonUtility.ToJson(data));
    }

    private string GetPatch(string key) => $"{Application.persistentDataPath}/{key}.json";
}