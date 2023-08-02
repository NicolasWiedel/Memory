using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int identifier;

    public float targetHeight = 0.01f;
    public float targetRotation = -90f;

    public void OnMouseDown()
    {
        Debug.Log("Mousetaste gedrückt!");
        FindObjectOfType<GameManager>().CardClicked(this);
    }

    private void Update()
    {
        float heightValue = Mathf.MoveTowards(transform.position.y, targetHeight, 1 * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, heightValue, transform.position.y);
    }
}
