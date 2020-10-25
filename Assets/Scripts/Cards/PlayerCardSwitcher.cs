using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardSwitcher : MonoBehaviour
{
    private bool _Selectable { get; set; }

    private void Awake()
    {
        _Selectable = false;
    }
    private void OnEnable()
    {
        SwitchCards.Instance.Listener_PickPlayerCards += ActiveSelectableCard;
    }
    private void OnDisable()
    {
        SwitchCards.Instance.Listener_PickPlayerCards -= ActiveSelectableCard;
    }
    private void ActiveSelectableCard(bool _bool)
    {
        _Selectable = _bool;
    }
    public void Call_SetPlayerCard()
    {
        if (_Selectable)
            SwitchCards.Instance.SetPlayerCard(GetComponent<CardScript>());
    }
}
