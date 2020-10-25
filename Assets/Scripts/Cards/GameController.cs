using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Public
 
    public TMPro.TextMeshProUGUI PrintPoints;
    #endregion
    #region Serlializated
    [SerializeField] private List<CardData> List_ComparerList;
    [SerializeField] private SetPlayerHands _SetPlayerHands;
    [SerializeField] private SetTableHands _SetTableHands;
    #endregion
    #region NonSerialized
    private Dictionary<string, CardsInformation> Dictionary_Comparer = new Dictionary<string, CardsInformation>();
    private CardsOrderer _CardsOrderer;
    #endregion

    private void Start()
    {
        _CardsOrderer = new CardsOrderer();
        UIController.Instance.SETInitSesion(InitSesion);
        UIController.Instance.SETCheckSesion(CheckSession);
    }
    private void InitSesion()
    {
        SetPlayerHand();
        SetTableHand();
    }
    private void CheckSession()
    {
        CallOrderHands();
        FilterCards();
        CheckCardsRanks();
    }
    private void SetPlayerHand()
    {
        _SetPlayerHands.CreateHands(ref CardsCore.List_PlayerCards);
    }
    private void SetTableHand()
    {
        _SetTableHands.CreateHands(ref CardsCore.List_TableCards);
    }
    private void CallOrderHands()
    {
        List_ComparerList = _CardsOrderer.OrderedData(_SetPlayerHands.GetMergedPlayerCards());
    }
    private void FilterCards()
    {
        Dictionary_Comparer?.Clear();
        for (int i = 0; i < List_ComparerList.Count; i++)
        {
            if (Dictionary_Comparer.TryGetValue(List_ComparerList[i].CardNumber.ToString(), out CardsInformation outValue))
                outValue.Repetitive += 1;
            else
                Dictionary_Comparer.Add(List_ComparerList[i].CardNumber.ToString(), new CardsInformation(List_ComparerList[i].CardNumber, 0));
        }
    }
    private void CheckCardsRanks()
    {
        int mPairAmount = 0;
        foreach (var item in Dictionary_Comparer)
        {
            if (item.Value.Repetitive >= 1)
            {
                mPairAmount += 1;
            }
        }

        PrintPoints.text = "Buena Suerte para la próxima";

        if (CheckCardSecuence() < 0)
        {
            if (mPairAmount == 1)
                PrintPoints.text = ("Has ganado 1 punto por un Par");

            if (mPairAmount == 2)
                PrintPoints.text = ("Has ganado 3 puntos con 2 Pares Diferentes");

            if (mPairAmount == 3)
                PrintPoints.text = ("Has ganado 5 puntos , con 3 cartas del mismo rango ");

            if (mPairAmount == 4)
                PrintPoints.text = ("Has ganado un AKA 20 puntos , 4 cartas del mismo rango");
        }
        else
        {
            PrintPoints.text = ("Has ganado 10 puntos con una secuencia");
        }
    }
    private int  CheckCardSecuence()
    {
        int mToreturn = 1;
        int mBaseNumber = List_ComparerList[0].CardNumber;
        for (int i = 1; i < List_ComparerList.Count; i++)
        {
            if (List_ComparerList[i].CardNumber != mBaseNumber + i)
            {
                mToreturn = -1;
                break;
            }
                
        }
        return mToreturn;
    }

    public void OnReset()
    {
        List_ComparerList.Clear();
        Dictionary_Comparer.Clear();
    }
  
}
public class CardsInformation
{
    public int CardNumber;
    public int Repetitive;
    public CardsInformation(int _InputCardNumber , int _InputRepetitive)
    {
        CardNumber = _InputCardNumber;
        Repetitive = _InputRepetitive;
    }
}
