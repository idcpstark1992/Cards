using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCardSwitcher : MonoBehaviour 
{
    public void CallSwithTableCard()
    {
        if (!SwitchCards.Instance.PressedTableCard && !SwitchCards.Instance.Blocked)
        {
            SwitchCards.Instance.SetTableCard(GetComponent<CardSelectable>().thisCardData,gameObject);
            SwitchCards.Instance.SetPresetTableStatus(true);
        }        
    }
    private void OnMouseDown()
    {
        CallSwithTableCard();
    }
}
