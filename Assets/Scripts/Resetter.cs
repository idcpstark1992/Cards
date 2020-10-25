using UnityEngine.Events;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] private UnityEvent ToCallAction;
    private void OnEnable()
    {
        ResetterListener.Lisetner_Reset += OnReset;
    }
    private void OnDisable()
    {
        ResetterListener.Lisetner_Reset -= OnReset;
    }

    private void OnReset()
    {
        ToCallAction?.Invoke();
    }
}
