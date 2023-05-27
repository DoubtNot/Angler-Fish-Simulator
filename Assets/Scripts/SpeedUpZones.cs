using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpZones : MonoBehaviour
{
    float speed, accel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUpZone")
        {
            speed += accel;
        }
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
