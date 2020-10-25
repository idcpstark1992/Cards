using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardSetHands : MonoBehaviour
{
    public abstract void CreateHands(ref List <CardData> _inputData);
}
