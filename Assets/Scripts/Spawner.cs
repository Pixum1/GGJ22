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

    public bool slomo;
    float slomoVal;

    [SerializeField]
    private Material groundWave;

    private void Start()
    {
        slomo = false;
        StartCoroutine("Spawn");
        laneWidth = transform.parent.lossyScale.x*10;
        transform.localPosition = new Vector3(0,0,transform.parent.lossyScale.z);
    }

    private void ScrollGroundWave() {
        groundWave.mainTextureOffset -= new Vector2(0, speed * slomoVal * .00025f);
    }

    private void Update() {
        ScrollGroundWave();
    }

    IEnumerator Spawn()
    {        
        if (slomo)
        {
            slomoVal = 0.4f;
        }
        else
        {
            slomoVal = 1;
        }

        
        if (isActive)
        {
            if(spawnTime>0.2f)
            spawnTime -= 0.01f / slomoVal;

            if (speed < 40f)
                speed += 0.1f/slomoVal;

            int i = Random.Range(0,obstacles.Count);
            float height=1;
            point = new Vector3(Random.Range(transform.position.x - laneWidth*0.5f+obstacles[i].transform.lossyScale.x, transform.position.x+ laneWidth * 0.5f - obstacles[i].transform.lossyScale.x), transform.position.y, transform.position.z);
            GameObject clone = Instantiate(obstacles[i], point+new Vector3(0,height*0.5f,0), Quaternion.identity);
            clone.transform.SetParent(this.transform);
            if(clone.tag== "ObstaclePushBack")
            {
                Vector3 planeScale = transform.parent.transform.localScale;
                clone.transform.localScale = new Vector3(Random.Range(4,9)/planeScale.x,1 / planeScale.y, 1 / planeScale.z);
            }
            Rigidbody rb=clone.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            clone.GetComponent<Collider>().isTrigger = true;
            rb.useGravity = false;
            
            List<Transform> children=new List<Transform>();

            for (int c = 0; c < transform.childCount; c++)
            {
                children.Add(transform.GetChild(c));
                children[c].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed*slomoVal);
            }

            yield return new WaitForSeconds(spawnTime / slomoVal);
        }        
        StartCoroutine("Spawn");
    }
}
