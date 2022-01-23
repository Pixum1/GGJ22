using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBorder : MonoBehaviour
{
    [SerializeField]
    float spawnTime;
    [SerializeField]
    GameObject block;

    private void Start()
    {
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        GameObject clone = Instantiate(block, transform.position, Quaternion.identity);
        Rigidbody rb = clone.AddComponent<Rigidbody>();
        clone.GetComponent<Collider>().isTrigger = true;
        clone.transform.localScale = new Vector3(1,1,5);
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, -30);
        yield return new WaitForSeconds(spawnTime);        
        StartCoroutine("Spawn");
    }
}
