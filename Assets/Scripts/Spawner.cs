using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> obstacles;
    Vector3 point;
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
        laneWidth = transform.parent.lossyScale.x*10;
        transform.localPosition = new Vector3(0,0,transform.parent.lossyScale.z);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        if (isActive)
        {
            if(spawnTime>0.2f)
            spawnTime -= 0.01f;

            if (speed < 40f)
                speed += 0.1f;

            int i = Random.Range(0,obstacles.Count);
            float height=1;
            point = new Vector3(Random.Range(transform.position.x - laneWidth*0.5f+obstacles[i].transform.lossyScale.x, transform.position.x+ laneWidth * 0.5f - obstacles[i].transform.lossyScale.x), transform.position.y, transform.position.z);
            GameObject clone = Instantiate(obstacles[i], point+new Vector3(0,height*0.5f,0), Quaternion.identity);
            if(clone.tag== "ObstaclePushBack")
            {
                clone.transform.localScale = new Vector3(Random.Range(4,9),1,1);
            }
            Rigidbody rb=clone.AddComponent<Rigidbody>();
            clone.GetComponent<Collider>().isTrigger = true;
            rb.useGravity = false;
            rb.velocity = new Vector3(0,0,-speed);
        }        
        StartCoroutine("Spawn");
    }
}
