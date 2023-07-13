using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject cannonBall;

    public Transform spawnPoint;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall") || collision.gameObject.CompareTag("PufferFish"))
        {
            GameObject ball = Instantiate(cannonBall, spawnPoint.position, Quaternion.identity);

            Destroy(ball, 8.0f);
        }
    }


}
