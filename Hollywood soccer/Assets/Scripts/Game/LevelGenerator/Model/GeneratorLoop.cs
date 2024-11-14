using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

public class GeneratorLoop : MonoBehaviour
{
    [SerializeField][Min(0.1f)] private float _interval;
    [SerializeField] private float _tileSize = 20;
    [SerializeField] private float _destroyYPosition = -5;
    [SerializeField] private int _initialTilesCount = 3;
    [SerializeField] private LevelSpawner _spawner;

    [Inject] private LevelGeneratorModel _generatorModel;

    private CancellationTokenSource _loopCancellationToken;

    private int _currentCheckIndex;

    private void Start()
    {
        _loopCancellationToken = new CancellationTokenSource();

        Loop().Forget();
    }

    private void OnDestroy()
    {
        _loopCancellationToken.Cancel();
    }

    private async UniTask Loop()
    {
        for (int i = 0; i < _initialTilesCount; i++)
        {
            _generatorModel.Generate();
            _spawner.Tiles[_spawner.Tiles.Count - 1].position = new Vector3(0f, _tileSize * i, 0f);
        }

        while (true)
        {
            if (ProcessFarTiles())
            {
                _generatorModel.Generate();
            }

            //if (_spawner.Tiles.Count == 0 || _spawner.Tiles[_currentCheckIndex].position.y < _lastYPosition)
            //{
            //    _generatorModel.Generate();
            //    GetCheckIndex();
            //}

            await UniTask.WaitForSeconds(_interval, cancellationToken: _loopCancellationToken.Token);
        }
    }

    private void GetCheckIndex()
    {
        _currentCheckIndex = _spawner.Tiles.Count - 1;
    }

    private bool ProcessFarTiles()
    {
        int lenght = _spawner.Tiles.Count;

        for (int i = 0; i < lenght; i++)
        {
            if (_spawner.Tiles[i].position.y < _destroyYPosition)
            {
                _spawner.RemoveTille(i);
                GetCheckIndex();

                return true;
            }
        }

        return false;
    }
}