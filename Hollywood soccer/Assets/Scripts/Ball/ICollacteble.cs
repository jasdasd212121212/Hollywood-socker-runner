using System;

public interface ICollacteble
{
    event Action<int> collectedWithScore;
    event Action collected;
}