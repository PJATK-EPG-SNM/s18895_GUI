using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersStartCollision : MonoBehaviour
{
    public BoxCollider2D villColl;

    void start()
    {
        villColl.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            villColl.enabled = true;
        }
    }

}
