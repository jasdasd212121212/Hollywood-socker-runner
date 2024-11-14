using System;
using UnityEngine;

public class PauseModel : MonoBehaviour
{
    public event Action paused;
    public event Action resume;

    private void Start()
    {
        SetPaused(false);
    }

    public void SetPaused(bool state)
    {
        if (state == true)
        {
            Time.timeScale = 0;
            paused?.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            resume?.Invoke();
        }
    }
}