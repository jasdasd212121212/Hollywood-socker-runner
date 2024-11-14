using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private LevelTileMover _tileMoverPrefab;

    [Space]

    [SerializeField] private SignatureMarcup_Enemy _enemyPrefab;
    [SerializeField] private SignatureMarcup_Colletable[] _collectablePrefabs;

    [Inject] private IReadOnlyLevelGenerator _levelGenerator;

    private MonoFactory<LevelTileMover> _tileMoverFactory;
    private MonoFactory<SignatureMarcup_Enemy> _enemyFactory;
    private MonoFactory<SignatureMarcup_Colletable> _collectableFactory;

    private List<Transform> _tiles = new List<Transform>();

    public IReadOnlyList<Transform> Tiles => _tiles;

    [Inject]
    private void Construct()
    {
        _tileMoverFactory = new MonoFactory<LevelTileMover>(_tileMoverPrefab);
        _enemyFactory = new MonoFactory<SignatureMarcup_Enemy>(_enemyPrefab);
        _collectableFactory = new MonoFactory<SignatureMarcup_Colletable>();

        _levelGenerator.levelTileGenerated += Spawn;
    }

    private void OnDestroy()
    {
        _levelGenerator.levelTileGenerated -= Spawn;
    }

    public void RemoveTille(int index)
    {
        Destroy(_tiles[index].gameObject);
        _tiles.RemoveAt(index);
    }

    private void Spawn(LevelGeneratorLine[] lines)
    {
        Transform tileMover = _tileMoverFactory.Create(Vector3.zero, Quaternion.identity).transform;

        foreach (LevelGeneratorLine line in lines)
        {
            foreach (Vector3 enemy in line.EnemyesPositions)
            {
                _enemyFactory.Create(enemy, Quaternion.identity).transform.SetParent(tileMover);
            }

            foreach (KeyValuePair<Vector3, int> collectable in line.CollectablesPositions)
            {
                _collectableFactory.Create(_collectablePrefabs[collectable.Value], collectable.Key, Quaternion.identity).transform.SetParent(tileMover);
            }
        }

        _tiles.Add(tileMover);  
    }
}