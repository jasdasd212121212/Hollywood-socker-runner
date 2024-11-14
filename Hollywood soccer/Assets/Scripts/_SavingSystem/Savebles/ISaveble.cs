using System;

public interface ISaveble<T>
{
    event Action dataChanged;
    T GetSaveDataTransferObject();
    void SetData(T data);
}