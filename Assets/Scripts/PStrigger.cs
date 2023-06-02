using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStrigger : MonoBehaviour
{

    public GameObject smokeyBurst;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject spill = Instantiate(smokeyBurst) as GameObject;
            spill.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            Destroy(this.gameObject);
            Destroy(spill, 2.0f);
        }
    }
}
