using System.Linq;
using System.Collections.Generic;
public class CardsOrderer
{
    public List<CardData> OrderedData(List<CardData> _inputList)
    {
        return _inputList.OrderBy(x => x.CardNumber).ToList();
    }

}
