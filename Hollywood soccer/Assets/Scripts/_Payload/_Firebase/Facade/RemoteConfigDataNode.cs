using System;

[Serializable]
public class RemoteConfigDataNode
{
    private string _key;
    private string _value;

    public string Key => _key;
    public string Value => _value;

    public RemoteConfigDataNode(string key, string value)
    {
        _key = key;
        _value = value;    
    }
}