using System;

public interface IReadOnlyLevelGenerator
{
    event Action<LevelGeneratorLine[]> levelTileGenerated;
}