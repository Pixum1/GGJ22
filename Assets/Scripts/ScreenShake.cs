using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    float amount = 0.1f;
    [SerializeField]
    int length = 5;
    [SerializeField]
    float seconds = 0.02f;

    public void StartShake()
    {
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {
        for (int i = 0; i < length; i++)
        {
            transform.position += new Vector3(0, amount * 8, 0);
            yield return new WaitForSeconds(seconds);
            transform.position -= new Vector3(0, amount * 8, 0);
            yield return new WaitForSeconds(seconds);
            transform.position += new Vector3(0, amount * 4, 0);
            yield return new WaitForSeconds(seconds);
            transform.position -= new Vector3(0, amount * 4, 0);
            yield return new WaitForSeconds(seconds);
            transform.position += new Vector3(0, amount * 2, 0);
            yield return new WaitForSeconds(seconds);
            transform.position -= new Vector3(0, amount * 2, 0);
            yield return new WaitForSeconds(seconds);
            transform.position += new Vector3(0, amount, 0);
            yield return new WaitForSeconds(seconds);
            transform.position -= new Vector3(0, amount, 0);
            yield return new WaitForSeconds(seconds);
        }
    }
}
