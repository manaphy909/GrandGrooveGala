using System;
using System.Diagnostics;
using UnityEngine;

public class MaskTrackerComponent : MonoBehaviour
{
    public int activeMask;

    public int ComparisonInt;

    public Material[] MaskMat;

    public bool IsPlayer;
    
    MeshRenderer Rend;

    public MaskTypes activeMaskEnum;
    void Start()
    {
        activeMask = UnityEngine.Random.Range(0, 4);
        //UnityEngine.Debug.Log(activeMask);

        Rend = GetComponent<MeshRenderer>();


        MaskSelection();
    }
    private void MaskSelection()
    {
        activeMaskEnum = (MaskTypes)activeMask;
        switch (activeMaskEnum)
        {
            case MaskTypes.Sloth:
                Rend.material = MaskMat[activeMask];
                break;

            case MaskTypes.Lust:
                Rend.material = MaskMat[activeMask];
                break;

            case MaskTypes.Wrath:
                Rend.material = MaskMat[activeMask];
                break;

            case MaskTypes.Coward:
                Rend.material = MaskMat[activeMask];
                break;
        }
    }


    public void CheckObject()
    {

        if(gameObject.tag == "Player")
        {

            IsPlayer = true;

        }
        else
        {

            IsPlayer = false;

        }




    }




}



