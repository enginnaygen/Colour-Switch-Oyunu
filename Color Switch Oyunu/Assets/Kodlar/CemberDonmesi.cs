using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemberDonmesi : MonoBehaviour
{
    public static float donmeHizi=2f;


    void FixedUpdate()
    {
        CemberDonmesii();
    }

    public void CemberDonmesii()
    {
        transform.Rotate(0, 0, donmeHizi);

    }
}

