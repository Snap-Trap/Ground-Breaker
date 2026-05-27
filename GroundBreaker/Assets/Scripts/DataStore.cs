using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    private Dictionary<string, object> _data = new Dictionary<string, object>();

    public T? GetData<T>(string name)
    {
        if (_data.TryGetValue(name, out var data))
        {
            return (T)data;
        }

        return default;
    }

    public void SetData<T>(string name, T data)
    {
        _data[name] = data;
    }
}
