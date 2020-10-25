using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTableHands : CardSetHands
{
    [SerializeField] private List<GameObject> List_TableList = new List<GameObject>();
    [SerializeField] private List<Transform> List_TableCardsPositions = new List<Transform>();
    public override void CreateHands(ref List<CardData> _inputData)
    {
        for (int i = 0; i < _inputData.Count; i++)
        {
            List_TableList[i].GetComponent<IAddCardData>().AddCardData(_inputData[i]);
            List_TableList[i].GetComponent<IShowCard>().EnterAnimation(List_TableCardsPositions[i].position);

        }
    }
    public void Onreset()
    {
        for (int i = 0; i < List_TableList.Count; i++)
        {
            List_TableList[i].GetComponent<IShowCard>().ResetAnimation();
        }
    }
}
