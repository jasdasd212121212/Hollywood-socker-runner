using System;

public interface IKIllable
{
    event Action dead; 

    void Kill();
    void SetImmortality(bool state);
}