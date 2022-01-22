using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject obstacle;
    Vector3 point;
    [SerializeField]
    float laneWidth;
    [SerializeField]
    float spawnTime;
    [SerializeField]
    float speed;
    [SerializeField]
    bool isActive;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        if (isActive)
        {            
            point = new Vector3(Random.Range(transform.position.x - laneWidth*0.5f, transform.position.x+ laneWidth * 0.5f), transform.position.y, transform.position.z);
            GameObject clone = Instantiate(obstacle, point, Quaternion.identity);
            Rigidbody rb=clone.AddComponent<Rigidbody>();
            clone.GetComponent<Collider>().isTrigger = true;
            rb.useGravity = false;
            rb.velocity = new Vector3(0,0,-speed);
        }        
        StartCoroutine("Spawn");
    }
}