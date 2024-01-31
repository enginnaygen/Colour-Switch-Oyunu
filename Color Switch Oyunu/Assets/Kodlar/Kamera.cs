using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform TopPozisyonu;
    public AudioSource arkaplansesi;

    
    void Update()
    {
      

        if (TopPozisyonu.position.y>transform.position.y)
        {
            transform.position = new Vector2(transform.position.x,TopPozisyonu.position.y);

        }
    }
}
