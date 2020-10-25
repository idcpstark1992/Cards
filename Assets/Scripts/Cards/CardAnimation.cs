using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public void EnterCards(Vector3 _position)
    {
        LeanTween.move(gameObject, _position, .1f);
    }
}
