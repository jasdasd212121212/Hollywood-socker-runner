using System;

public interface ILocker
{
    event Action started;
    event Action compleated;
}