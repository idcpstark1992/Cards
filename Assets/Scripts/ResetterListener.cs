using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetterListener : MonoBehaviour
{
    public delegate void DelegateOnreset();
    public static DelegateOnreset Lisetner_Reset;
    public void CallReset()
    {
        Lisetner_Reset?.Invoke();
    }
}
