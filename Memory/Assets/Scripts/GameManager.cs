using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipCardUp;
    public AudioClip clipCardDown;
    public AudioClip clipCardMatch;

    private MemoryCard firstSelectedCard;
    private MemoryCard secondSelectedCard;

    private bool canClick = true;

    public GameObject[] allCards;

    private void Awake()
    {
        foreach(GameObject card in allCards)
        {
            Debug.Log(card.transform.position);
        }
    }

    public void CardClicked(MemoryCard card)
    {
        if(canClick == false)
        {
            return;
        }

        card.targetRotation = 90;
        card.targetHeight = 0.05f;
        audioSource.PlayOneShot(clipCardUp);

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
            audioSource.PlayOneShot(clipCardMatch);
        }

        else
        {
            firstSelectedCard.targetRotation = -90;
            secondSelectedCard.targetRotation = -90;

            firstSelectedCard.targetHeight = 0.01f;
            secondSelectedCard.targetHeight = 0.01f;

            audioSource.PlayOneShot(clipCardDown);
        }

        firstSelectedCard = null;
        secondSelectedCard = null;

        canClick = true;
    }
}
