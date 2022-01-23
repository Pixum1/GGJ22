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
    private PlayerController otherPCon;
    [SerializeField]
    GameObject otherPlayer;

    private void Start()
    {
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
            powerUpTimer = 5f;
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
}
