using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnDestroy : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pSys;
    Spawner spawn;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip audioClip;

    private void Start()
    {
        audioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        spawn = GetComponentInParent<Spawner>();

        if (other.tag == "Player")
        {
            pSys.GetComponent<ParticleSystemRenderer>().material = transform.GetComponent<MeshRenderer>().material;
            var main = pSys.main;
            Instantiate(pSys, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioClip);
            if (spawn.slomo)
            {                
                main.simulationSpeed = 0.4f;
            }
            else
            {
                main.simulationSpeed = 1f;
            }
        }
    }
}
