using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanFollow : MonoBehaviour
{

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float zMin;

    [SerializeField]
    private float zMax;

    public Transform targetObject;



    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(targetObject.position.x, xMin, xMax), Mathf.Clamp(targetObject.position.y, yMin, yMax), Mathf.Clamp(targetObject.position.z, zMin, zMax));
    }
}
