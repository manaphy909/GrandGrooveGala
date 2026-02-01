using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
File: SemiTransparentObjectComponent.cs
Author: Atlas Stewart
DP Email: atlas.stewart@digipen.edu
Date: 10/8/2025
Course: CS176
Section: A
Description:
A script that lets the semitransparent objects work
**/
public class SemiTransparentObjectComponent : MonoBehaviour
{
    public Material DefaultMaterial;
    public Material SemiTransparentMaterial;

    private MeshRenderer MR;

    private float restoreMatTimer = 5f;
    public float restoreMatDelay = 1f;

    private void Awake()
    {
        MR = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //making sure the timer ticks
        restoreMatTimer += Time.deltaTime;
        //counting up until finally setting back to efault
        if (restoreMatTimer >= restoreMatDelay)
        {
            SwapToDefault();
        }
    }

    public void SwapToSemiTrans()
    {
        MR.material = SemiTransparentMaterial;
        restoreMatTimer = 0f;
    }
    public void SwapToDefault()
    {
        MR.material = DefaultMaterial;
    }
}
