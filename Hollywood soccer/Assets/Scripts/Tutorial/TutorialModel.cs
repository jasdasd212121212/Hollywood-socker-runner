using UnityEngine;
using System;

public class TutorialModel : MonoBehaviour, ILocker
{
    [SerializeField] private int _tutorialPagesCount;

    private int _currentStepIndex;

    public int CurrentStepIndex => _currentStepIndex;

    public event Action started;
    public event Action next;
    public event Action compleated;

    private void Start()
    {
        if (PlayerPrefs.HasKey(SavingSystemConfig.TUTORIAL_IS_COMPLEATED) == false || PlayerPrefsExtanded.GetBool(SavingSystemConfig.TUTORIAL_IS_COMPLEATED) == false)
        {
            started?.Invoke();
        }
    }

    public void Next()
    {
        if ((_currentStepIndex + 1) >= _tutorialPagesCount)
        {
            PlayerPrefsExtanded.SetBool(SavingSystemConfig.TUTORIAL_IS_COMPLEATED, true);
            _currentStepIndex = _tutorialPagesCount - 1;

            compleated?.Invoke();
        }
        else
        {
            _currentStepIndex++;
            next?.Invoke();
        }
    }
}