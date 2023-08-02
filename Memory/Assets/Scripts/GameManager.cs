using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MemoryCard firstSelectedCard;
    public MemoryCard secondSelectedCard;

    private bool canClick = true;

    public void CardClicked(MemoryCard card)
    {
        if(canClick == false)
        {
            return;
        }

        card.transform.localEulerAngles = new Vector3(90, 0, 0);
        card.targetHeight = 0.05f;

        if(firstSelectedCard == null)
        {
            firstSelectedCard = card;
        }
        else
        {
            secondSelectedCard = card;

            canClick = false;

            Invoke("CheckMatch", 1);
        }
       
    }

    private void CheckMatch()
    {
        if (firstSelectedCard.identifier == secondSelectedCard.identifier)
        {
            Destroy(firstSelectedCard.gameObject);
            Destroy(secondSelectedCard.gameObject);
        }

        else
        {
            firstSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);
            secondSelectedCard.transform.localEulerAngles = new Vector3(-90, 0, 0);

            firstSelectedCard.targetHeight = 0.01f;
            secondSelectedCard.targetHeight = 0.01f;
        }

        firstSelectedCard = null;
        secondSelectedCard = null;

        canClick = true;
    }
}
