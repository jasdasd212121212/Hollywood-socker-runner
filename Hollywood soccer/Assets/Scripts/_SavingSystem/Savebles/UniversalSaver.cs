public class UniversalSaver<T>
{
    private ISavingSystem _system;
    private ISaveble<T> _target;

    private string _saveKey;

    public UniversalSaver(ISavingSystem system, ISaveble<T> target, string saveKey)
    {
        _system = system;
        _target = target;
        _saveKey = saveKey;

        if (_system.HasKey(_saveKey))
        {
            _target.SetData(_system.Load<T>(_saveKey));
        }
        else
        {
            Save();
        }

        _target.dataChanged += Save;
    }

    ~UniversalSaver() 
    {
        if(_target != null)
        {
            Save();
            _target.dataChanged -= Save;
        }
    }

    private void Save()
    {
        _system.Save(_saveKey, _target.GetSaveDataTransferObject());
    }
}