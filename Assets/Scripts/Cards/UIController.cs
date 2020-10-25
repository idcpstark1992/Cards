using UnityEngine.Events;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance = null;
    private UnityAction _initAction;
    private UnityAction _CheckAction;
    private UnityAction _ResetAction;
    private void Awake()
    {
        Instance = this;
    }
    public void SETInitSesion(UnityAction _InputAction)
    {
        _initAction = _InputAction;
    }
    public void SETCheckSesion(UnityAction _inputAction)
    {
        _CheckAction = _inputAction;
    }
    public void SETResetSesion(UnityAction _inputAction)
    {
        _ResetAction = _inputAction;
    }

    public void CallInitSesion()
    {
        _initAction?.Invoke();
    }
    public void CallCheckSession()
    {
        _CheckAction?.Invoke();
    }
    public void CallResetSesison()
    {
        _ResetAction.Invoke();
    }

}
