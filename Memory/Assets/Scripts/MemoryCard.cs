using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int identifier;

    public void OnMouseDown()
    {
        Debug.Log("Mousetaste gedr�ckt!");
        FindObjectOfType<GameManager>().CardClicked(this);
    }
}
