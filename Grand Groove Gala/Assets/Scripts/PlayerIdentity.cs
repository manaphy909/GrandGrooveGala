using System;
using System.Diagnostics;
using UnityEngine;

public enum MaskTypes
{ Sloth, Lust, Wrath, Coward }

public class PlayerIdentity : MonoBehaviour
{
    //public int activeMask;


    public MaskTypes activeMaskEnum;
    private void Awake()
    {
        //activeMask = UnityEngine.Random.Range(0, 4);
        //UnityEngine.Debug.Log(activeMask);

        SetActiveMask();
    }
    public void SetActiveMask()
    {
        //activeMaskEnum = (MaskTypes)activeMask;
        switch (activeMaskEnum)
        {
            case MaskTypes.Sloth:
                UnityEngine.Debug.Log("Sloth");
                break;

            case MaskTypes.Lust:
                UnityEngine.Debug.Log("Lust");
                break;

            case MaskTypes.Wrath:
                UnityEngine.Debug.Log("Wrath");
                break;

            case MaskTypes.Coward:
                UnityEngine.Debug.Log("Coward");
                break;
        }

        //print(activeMaskEnum);


    }



}
