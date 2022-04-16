using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.CompareTag("Item"))
        {
            Debug.Log("Success!");
        }
    }
}
