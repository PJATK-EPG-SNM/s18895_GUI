using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeart : MonoBehaviour
{

   public  void set(Material mat)
    {
        gameObject.GetComponent<SpriteRenderer>().material = mat;
    }

}
