using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
File: CameraOcclusion.cs
Author: Atlas Stewart
DP Email: atlas.stewart@digipen.edu
Date: 10/8/2025
Course: CS176
Section: A
Description:
A script that handles all camera occlusion effects, including an epsilon and masking for different objects to be semitransparent, ignored, or occluded.
**/
public class CameraOcclusion : MonoBehaviour
{
    // desired distance from camera positive absolute value (negate this)
    public float defaultZoom = 1f;

    //the pushing a little closer to the player variable
    public float zoomEpsilon;

    //occlusion mask
    public LayerMask OcclusionMask;

    //lerping variable
    [Range(0f, 1f)]
    public float zoomInterpolant = .9f;

    //for raycast but use move pivot instead of yaw, as it acts the same but includes the updated pivot settings
    public Transform yawPivotTransform;


    // Update is called once per frame
    void Update()
    {
        //prepare for raycast second param
        Vector3 rayDir = (transform.position - yawPivotTransform.position).normalized;
        //make and shoot targetted raycast
        Ray occlusionRay = new Ray(yawPivotTransform.position, rayDir);

        //set default zoom again
        float targetZoom = defaultZoom;


        //do our occlusion but make sure that it is not of the layers that ignore raycast or ignore occlusion
        RaycastHit[] results = Physics.RaycastAll(occlusionRay, defaultZoom + zoomEpsilon, OcclusionMask);

        Debug.Log(results.Length);

        if (results.Length > 0)
        {
            for (int i = 0; i < results.Length; ++i)
            {

                SemiTransparentObjectComponent obj = results[i].collider.gameObject.GetComponent<SemiTransparentObjectComponent>();
                if (obj != null)
                {
                    //if it is semi transparent
                    obj.SwapToSemiTrans();
                }
                else
                {
                    targetZoom = Mathf.Min(targetZoom, (results[i].distance - zoomEpsilon));
                }
            }

            //transform.localPosition = new Vector3(0f, 0f, );
        }

        Vector3 targetPos = new Vector3(0f, 0f, -targetZoom);
        //interpolating
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, zoomInterpolant);
    }
}
