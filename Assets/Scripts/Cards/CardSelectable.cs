using UnityEngine;
public class CardSelectable : MonoBehaviour , IAddCardData, IShowCard
{
    public CardData thisCardData;
    [SerializeField] private Vector3 _OriginalPosition;
    private void Start()
    {
        _OriginalPosition = gameObject.transform.position;
    }
    public void AddCardData(CardData _InputData)
    {
        thisCardData = _InputData;
    }

    public void EnterAnimation(Vector3 _newpos)
    {
        LeanTween.move(gameObject, _newpos, .1f);
    }

    public void ExitAnimation(Vector3 _newpos)
    {
        gameObject.transform.position = _newpos;
    }
  
    public void ResetAnimation()
    {
        gameObject.transform.position = _OriginalPosition;
    }
}
