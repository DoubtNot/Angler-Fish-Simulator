﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    public float wavesHeight = 5f;

    public float wavesFrequency = 4f;

    public float wavesSpeed = 7f;

    public Transform ocean;

    Material oceanMat;

    Texture2D wavesDisplacement;

    void Start()
    {
        SetVariables();
    }

    void SetVariables() 
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        wavesDisplacement = (Texture2D)oceanMat.GetTexture("_WavesDisplacement");
    }

    public float WaterHeightAtPosition(Vector3 position) 
    {
        return ocean.position.y +  wavesDisplacement.GetPixelBilinear(position.x * wavesFrequency / 100, position.z * wavesFrequency / 100 + Time.time * wavesSpeed / 100).g * wavesHeight / 100 * ocean.localScale.x;
    }

    void OnValidate()
    {
        if (!oceanMat)
            SetVariables();

        UpdateMaterial();
    }

    void UpdateMaterial() 
    {
        oceanMat.SetFloat("_WavesFrequency", wavesFrequency/100);
        oceanMat.SetFloat("_WavesSpeed", wavesSpeed/100);
        oceanMat.SetFloat("_WavesHeight", wavesHeight*100);
    }
}
