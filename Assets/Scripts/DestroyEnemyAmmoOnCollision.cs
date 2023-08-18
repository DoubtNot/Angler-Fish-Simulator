using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAmmoOnCollision : MonoBehaviour
{
    public GameObject smokeyBurst;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnSmokeyBurst();
            Destroy(gameObject);
        }
    }

    private void SpawnSmokeyBurst()
    {
        GameObject spill = Instantiate(smokeyBurst) as GameObject;
        spill.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);

        Destroy(spill, 2.0f);
    }
}
