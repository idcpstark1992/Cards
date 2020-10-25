public interface IComparation
{
    void CompareCards(bool _tableCard);
}
public interface IAddCardData
{
    void AddCardData(CardData _InputData);
}
public interface IShowCard
{
    void EnterAnimation(UnityEngine.Vector3 _newpos);
    void ExitAnimation(UnityEngine.Vector3 _newpos);
    void ResetAnimation();
}