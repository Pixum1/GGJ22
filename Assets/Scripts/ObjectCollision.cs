using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    string activeObstacleTag;
    string activePowerUpTag;
    float hitPosZ;
    [SerializeField]
    float powerUpTimer;
    private PlayerController pCon;
    [SerializeField]
    private Spawner pSpawner;
    [SerializeField]
    private Spawner otherPSpawner;
    private PlayerController otherPCon;
    [SerializeField]
    GameObject otherPlayer;
    bool slomoon;
    float slomoTimer;

    private void Start()
    {
        slomoon = false;
        slomoTimer = 7;
        pCon = GetComponent<PlayerController>();
        otherPCon = otherPlayer.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<ScreenShake>().StartShake();
        if (other.tag.StartsWith("Obstacle"))
        {
            activeObstacleTag = other.tag;
        }else if (other.tag.StartsWith("PowerUp"))
        {
            activePowerUpTag = other.tag;
        }
        else if (other.tag=="SloMo")
        {
            slomoon = true;
        }
        hitPosZ = transform.position.z;
        if(!other.CompareTag("WallOfDeath"))
            Destroy(other.gameObject);
    }
    private void Update()
    {
        if (activeObstacleTag != null)
            Invoke(activeObstacleTag, 0);

        if (activePowerUpTag != null)
        {
            Invoke(activePowerUpTag, 0);
        }
        else
        {
            powerUpTimer = 7f;
        }

        if (slomoon)
        {
            SloMo();
        }
    }
    void ObstaclePushBack()
    {
        float dist = 4;
        if (transform.position.z > hitPosZ - dist)
        {
            transform.position += new Vector3(0, 0, -20f*Time.deltaTime);
        }
        else
        {
            activeObstacleTag = null;
        }
    }
    void ObstaclePullFwd()
    {
        float dist = 4;
        if (transform.position.z < hitPosZ + dist)
        {
            transform.position += new Vector3(0, 0, 20f * Time.deltaTime);
        }
        else
        {
            activeObstacleTag = null;
        }
    }
    void PowerUpInvert()
    {        
        powerUpTimer -= Time.deltaTime;

        if (!otherPCon.moveInvertet)
        {
            otherPCon.moveInvertet = true;
        }
        
        if (powerUpTimer <= 0)
        {
            otherPCon.moveInvertet = false;
            activePowerUpTag = null;
        }
    }

    void SloMo()
    {
        pSpawner.slomo = true;
        slomoTimer -= Time.deltaTime;

        if (slomoTimer <= 0)
        {
            pSpawner.slomo = false;
            slomoTimer = 7;
            slomoon = false;
        }
    }
}
