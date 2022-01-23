using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField]
    float p1Points;
    [SerializeField]
    float p2Points;

    [SerializeField]
    Transform p1;
    [SerializeField]
    Transform p2;
    [SerializeField]
    Transform wallOfDeath;


    private void Update()
    {
        p1Points += Time.deltaTime * (p1.position.z - wallOfDeath.position.z);
        p2Points += Time.deltaTime * (p2.position.z - wallOfDeath.position.z);
    }

}
