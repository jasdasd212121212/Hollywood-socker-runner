public interface ISavingSystem
{
    void Save<T>(string key, T data);
    T Load<T>(string key);
    bool HasKey(string key);
}