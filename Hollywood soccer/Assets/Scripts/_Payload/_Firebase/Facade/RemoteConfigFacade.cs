using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class RemoteConfigFacade
{
    private RemoteConfigDataNode[] _data;
    private bool _loaded;

    private Action loadedCallback;

    public void Initialize(Action loadedCallback)
    {
        this.loadedCallback = loadedCallback;

        Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

    public async UniTask<string> GetValueAsync(string key)
    {
        if (_loaded == false)
        {
            Initialize(null);
        }

        await UniTask.WaitWhile(() => _loaded == false);

        return GetValue(key);
    }

    public string GetValue(string key)
    {
        if (_loaded == false)
        {
            Debug.LogError("Critical error -> firebase now is not initialized, but you try to get permisson to read RemoteConfig");
            return null;
        }

        foreach (RemoteConfigDataNode item in _data)
        {
            if (item.Key == key)
            {
                return item.Value;
            }
        }

        Debug.LogError($"Critical error -> key: {key} are not exist");
        return null;
    }

    private void FetchComplete(Task fetchTask)
    {
        if (fetchTask.IsCompleted == false)
        {
            Debug.LogError("Critical error -> retrieval hasn't finished");
            return;
        }

        FirebaseRemoteConfig remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        ConfigInfo info = remoteConfig.Info;

        if (info.LastFetchStatus != LastFetchStatus.Success)
        {
            Debug.LogError($"Cirtical error -> {nameof(FetchComplete)} was unsuccessful \n {nameof(info.LastFetchStatus)} : {info.LastFetchStatus}");
            return;
        }

        BuildData(remoteConfig);
    }

    private void BuildData(FirebaseRemoteConfig remoteConfig)
    {
        remoteConfig.ActivateAsync()
          .ContinueWithOnMainThread(
            task =>
            {
                List<RemoteConfigDataNode> data = new List<RemoteConfigDataNode>();

                foreach (KeyValuePair<string, ConfigValue> node in remoteConfig.AllValues)
                {
                    data.Add(new RemoteConfigDataNode(node.Key, node.Value.StringValue));
                }

                _data = data.ToArray();

                _loaded = true;
                loadedCallback?.Invoke();
            });
    }
}