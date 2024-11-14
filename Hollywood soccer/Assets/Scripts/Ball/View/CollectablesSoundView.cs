using UnityEngine;

public class CollectablesSoundView : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField][Min(0.001f)] private float _soundDuration = 3f;

    private ICollacteble _self;

    private void OnValidate()
    {
        if (gameObject.GetComponent<ICollacteble>() == null)
        {
            Debug.LogError($"Critical error -> gameObject: {gameObject.name} are not contains any script realises: {nameof(ICollacteble)} interface");
            DestroyImmediate(this);
        }
    }

    private void Awake()
    {
        _self = GetComponent<ICollacteble>();

        _self.collected += OnCollect;
    }

    private void OnDestroy()
    {
        _self.collected -= OnCollect;
    }

    private void OnCollect()
    {
        _sound.transform.SetParent(null);
        Destroy(_sound.gameObject, _soundDuration);
        _sound.Play();   
    }
}