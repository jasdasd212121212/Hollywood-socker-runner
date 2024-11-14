using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class BacgroundMoveLoop : MonoBehaviour
{
    [SerializeField] private LevelTileMover _backgroundTilePrefab;
    [SerializeField] private float _chectInterval;
    [SerializeField] private float _lastYPosition;
    [SerializeField] private float _initialiYPoint;
    [SerializeField] private float _tileSize;

    private GameObjectMonoPool<LevelTileMover> _tilesPool;

    private CancellationTokenSource _loopCancellationToken;

    private const int POOL_SIZE = 2;

    private void Start()
    {
        _tilesPool = new GameObjectMonoPool<LevelTileMover>(_backgroundTilePrefab, transform, POOL_SIZE);
        _loopCancellationToken = new CancellationTokenSource();

        CheckLoop().Forget();
    }

    private void OnDestroy()
    {
        _loopCancellationToken.Cancel();
    }

    private async UniTask CheckLoop()
    {
        Init();

        while (true) 
        {
            for (int i = 0; i < POOL_SIZE; i++)
            {
                Transform tileTransform = _tilesPool.BusyPool[i].transform;

                if (tileTransform.position.y < _lastYPosition)
                {
                    tileTransform.position = new Vector3(0f, _initialiYPoint, 0f);
                    break;
                }
            }

            await UniTask.WaitForSeconds(_chectInterval, cancellationToken: _loopCancellationToken.Token);
        }
    }

    private void Init()
    {
        for (int i = 0; i < POOL_SIZE; i++)
        {
            _tilesPool.Pop().transform.position = new Vector3(0f, _initialiYPoint - _tileSize * i, 0f);
        }
    }
}