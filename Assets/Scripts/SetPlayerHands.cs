using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerHands : CardSetHands
{
    [SerializeField] private RectTransform PlayerHandsTransform;
    [SerializeField] private CardScript PrefabCardData;
    public List<CardData> GetMergedPlayerCards()
    {
        List<CardData> mToreturn = new List<CardData>();
        for (int i = 0; i < PlayerHandsTransform.childCount; i++)
            mToreturn.Add(PlayerHandsTransform.GetChild(i).GetComponent<CardScript>().DATA);

        return mToreturn;
    }
    public override void CreateHands(ref List<CardData> _inputData)
    {
        for (int i = 0; i < _inputData.Count; i++)
        {
            var toInstantiate = PrefabCardData;
            toInstantiate.gameObject.GetComponent<IAddCardData>().AddCardData(CardsCore.List_PlayerCards[i]);
            Instantiate(toInstantiate, PlayerHandsTransform);
        }
    }
    public void OnReset()
    {
        for (int i = 0; i < PlayerHandsTransform.childCount; i++)
        {
            PlayerHandsTransform.GetChild(i).GetComponent<CardsDestroyer>().OnResetCard();
        }
    }
}
