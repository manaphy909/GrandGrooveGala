using System;
using System.Diagnostics;
using UnityEngine;

public class MaskTrackerComponent : MonoBehaviour
{
    public int activeMask;

    public Material[] MaskMat;
    
    MeshRenderer Rend;

    public enum Mask
    { Sloth, Lust, Wrath, Coward }

    public Mask activeMaskEnum;
    void Start()
    {
        activeMask = UnityEngine.Random.Range(0, 4);
        UnityEngine.Debug.Log(activeMask);

        Rend = GetComponent<MeshRenderer>();


        MaskSelection();
    }
    private void MaskSelection()
    {
        activeMaskEnum = (Mask)activeMask;
        switch (activeMaskEnum)
        {
            case Mask.Sloth:
                Rend.material = MaskMat[activeMask];
                break;

            case Mask.Lust:
                Rend.material = MaskMat[activeMask];
                break;

            case Mask.Wrath:
                Rend.material = MaskMat[activeMask];
                break;

            case Mask.Coward:
                Rend.material = MaskMat[activeMask];
                break;
        }
    }
}
