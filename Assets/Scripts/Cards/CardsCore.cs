using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCore : MonoBehaviour
{
    public static List<CardData> List_MazeCards  = new List<CardData>();
    public static List<CardData> List_PlayerCards =  new List<CardData>();
    public static List<CardData> List_TableCards = new List<CardData>();

    private List<CardData> List_TemporalMazeCards;
    [SerializeField] private Sprite[] Array_Sprites;
    [SerializeField] private Sprite SpeciaSprite;
    [SerializeField] private int Amount_CardsPerSymbol;
    [SerializeField] private int Amount_Symbols;
    [SerializeField] private int InitialPlayerHand;
    [SerializeField] private int InitialTableHand;

    private void Start()
    {
        CreateCardDeck();
        CreatePlayerHand();
        CreateTableHand();
    }
    private void CreateCardDeck()
    {
        for (int cardSymbol = 0; cardSymbol < Amount_Symbols; cardSymbol++)
        {
            for (int cardNumber = 0; cardNumber < Amount_CardsPerSymbol; cardNumber++)
                List_MazeCards.Add(new CardData(cardNumber+1, cardSymbol,cardNumber >= 10 ? SpeciaSprite : Array_Sprites[cardSymbol]));
        }

        //for (int i = 0; i < List_MazeCards.Count; i++)
        //{
        //    Debug.Log(" Numero : " + List_MazeCards[i].CardNumber + " Symbol : " + List_MazeCards[i].CardSymbol + " Name " + List_MazeCards[i].SpriteRenderSymbol.name);
        //}
        CopyCardsToTemporal();
    }
    private void CopyCardsToTemporal()
    {
        List_TemporalMazeCards?.Clear();
        List_TemporalMazeCards = new List<CardData>(List_MazeCards);
    }
    private void CreatePlayerHand()
    {
        List_PlayerCards?.Clear();
        for (int i = 0; i < InitialPlayerHand; i++)
        {
            int mRandomIndex = Random.Range(0, List_TemporalMazeCards.Count);
            List_PlayerCards.Add(List_TemporalMazeCards[mRandomIndex]);
            List_TemporalMazeCards.RemoveAt(mRandomIndex);
        }
    }
    private void CreateTableHand()
    {
        List_TableCards?.Clear();
        for (int i = 0; i < InitialTableHand; i++)
        {
            int mRandomIndex = Random.Range(0, List_TemporalMazeCards.Count);
            List_TableCards.Add(List_TemporalMazeCards[mRandomIndex]);
            List_TemporalMazeCards.RemoveAt(mRandomIndex);
        }
    }

    public void OnReset()
    {
        CopyCardsToTemporal();
        CreatePlayerHand();
        CreateTableHand();
    }
}
[System.Serializable]
public class CardData
{
    public int CardNumber;
    public int CardSymbol;
    public Sprite SpriteRenderSymbol;
    public  CardData(int _InputCardNumber, int _inputCardSymbol, Sprite _InputSprite)
    {
        CardNumber = _InputCardNumber;
        CardSymbol = _inputCardSymbol;
        SpriteRenderSymbol = _InputSprite;
    }
}