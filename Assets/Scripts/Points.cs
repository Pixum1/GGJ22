using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField]
    public float p1Points;
    [SerializeField]
    public float p2Points;

    [SerializeField]
    Transform p1;
    [SerializeField]
    Transform p2;
    [SerializeField]
    Transform wallOfDeath;


    private void Update()
    {
        if(p1 != null && p2 != null) {
            p1Points += Time.deltaTime * (p1.position.z - wallOfDeath.position.z) * 5f;
            p2Points += Time.deltaTime * (p2.position.z - wallOfDeath.position.z) * 5f;
        }
    }

}
