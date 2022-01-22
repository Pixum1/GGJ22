using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    string activeObjTag;
    float hitPosZ;
    private PlayerController player;

    private void Awake() {
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hitPosZ = transform.position.z;
        activeObjTag = other.tag;
        Destroy(other.gameObject);
    }
    private void Update()
    {
        if (activeObjTag != null)
            Invoke(activeObjTag, 0);
    }
    void Obstacle()
    {
        float dist = 4;
        if (transform.position.z > hitPosZ - dist)
        {
            transform.position += new Vector3(0, 0, -20f*Time.deltaTime);
        }
        else
        {
            activeObjTag = null;
        }
    }
    void Obstacle2()
    {
        float dist = 4;
        if (transform.position.z < hitPosZ + dist && transform.position.z < player.maxHeightBounds)
        {
            transform.position += new Vector3(0, 0, 20f * Time.deltaTime);
        }
        else
        {
            activeObjTag = null;
        }
    }
}
