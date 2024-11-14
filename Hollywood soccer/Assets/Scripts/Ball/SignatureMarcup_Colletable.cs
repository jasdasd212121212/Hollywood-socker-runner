using UnityEngine;

public class SignatureMarcup_Colletable : MonoBehaviour
{
    private void OnValidate()
    {
        if (gameObject.GetComponent<ICollacteble>() == null)
        {
            Debug.LogError($"Critical error -> gameObject: {gameObject.name} are not contains any script realises {nameof(ICollacteble)} intreface");
        }
    }
}