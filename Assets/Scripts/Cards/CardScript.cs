using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour ,IAddCardData
{
    /// <summary>
    /// la carta # 0, se representará como el Az , el 11 = J , 12 = Q , 13 = K 
    /// </summary>
    [SerializeField] private CardData cardData;
    [SerializeField] private Image PrintImage;
    [SerializeField] private TMPro.TextMeshProUGUI PrintLetter;
    [SerializeField] private TMPro.TextMeshProUGUI PrintLowerLetter;
    public CardData DATA;

    private void PrintCardSymbols()
    {
        PrintImage.GetComponent<Image>().sprite = cardData.SpriteRenderSymbol;
        PrintLetter.text = cardData.CardNumber.ToString();
        
        if (cardData.CardNumber == 1)
            PrintLetter.text = "A";

        if (cardData.CardNumber == 11)
            PrintLetter.text = "J";

        if (cardData.CardNumber == 12)
            PrintLetter.text = "Q";

        if (cardData.CardNumber == 13)
            PrintLetter.text = "K";

        PrintLowerLetter.text = PrintLetter.text;
    }
    public void AddCardData(CardData _InputData)
    {
        cardData = _InputData;
        DATA = cardData;
        PrintCardSymbols();
    }
}
