using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    public int activeMask;
    public enum Mask
    { Sloth, Lust, Wrath, Sin }

    public Mask activeMaskEnum;
    private void Awake()
    {
        activeMask = UnityEngine.Random.Range(0, 4);
        UnityEngine.Debug.Log(activeMask);

        MaskSelection();
    }
    private void MaskSelection()
    {
        activeMaskEnum = (Mask)activeMask;
        switch (activeMaskEnum)
        {
            case Mask.Sloth:
                break;

            case Mask.Lust:
                break;

            case Mask.Wrath:
                break;

            case Mask.Sin:
                break;
        }
    }
}
