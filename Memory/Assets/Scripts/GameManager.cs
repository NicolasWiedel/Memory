using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MemoryCard firstSelectedCard;
    public MemoryCard secondSelectedCard;

    public void CardClicked(MemoryCard card)
    {
        if(firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            secondSelectedCard = card;
        }
       
    }
}
