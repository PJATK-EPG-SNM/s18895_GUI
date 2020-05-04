using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("pojawia sie drzewo");
        }
    }
}
