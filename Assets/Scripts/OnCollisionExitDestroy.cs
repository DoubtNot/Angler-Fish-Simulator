using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExitDestroy : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BowlingPin"))
        {
            Destroy(this.gameObject);
        }
    }
}
