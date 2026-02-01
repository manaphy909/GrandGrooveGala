using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{


    public RawImage[] ArrowArray;

    public Image[] MaskImages;

    PlayerMovementPrime PlayerRef;

    PlayerIdentity PlayerIdentity;

    public RawImage MyImage;

    public Image myimage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        PlayerRef = gameObject.GetComponent<PlayerMovementPrime>();

        PlayerIdentity = gameObject.GetComponent<PlayerIdentity>();

    }





    // Update is called once per frame
    void Update()
    {


        if (PlayerRef.DirectionToMoveX == "Up") { MyImage = ArrowArray[0].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[0].GetComponent<RawImage>().color = Color.white; }

        if (PlayerRef.DirectionToMoveX == "Down") { MyImage = ArrowArray[4].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[4].GetComponent<RawImage>().color = Color.white; }

        if (PlayerRef.DirectionToMoveY == "Left") { MyImage = ArrowArray[2].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[2].GetComponent<RawImage>().color = Color.white; }

        if (PlayerRef.DirectionToMoveY == "Right") { MyImage = ArrowArray[6].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[6].GetComponent<RawImage>().color = Color.white; }

        if ((PlayerRef.DirectionToMoveY == "Left") && (PlayerRef.DirectionToMoveX == "Up")) { MyImage = ArrowArray[7].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[7].GetComponent<RawImage>().color = Color.white; }

        if ((PlayerRef.DirectionToMoveY == "Right") && (PlayerRef.DirectionToMoveX == "Up")) { MyImage = ArrowArray[1].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[1].GetComponent<RawImage>().color = Color.white; }

        if ((PlayerRef.DirectionToMoveY == "Left") && (PlayerRef.DirectionToMoveX == "Down")) { MyImage = ArrowArray[5].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[5].GetComponent<RawImage>().color = Color.white; }

        if ((PlayerRef.DirectionToMoveX == "Down") && (PlayerRef.DirectionToMoveY == "Right")) { MyImage = ArrowArray[3].GetComponent<RawImage>(); MyImage.color = Color.red; } else { ArrowArray[3].GetComponent<RawImage>().color = Color.white; }


        if (PlayerIdentity.activeMaskEnum == MaskTypes.Sloth) { myimage = MaskImages[2].GetComponent<Image>();myimage.color = Color.red;} else { MaskImages[2].GetComponent<Image>().color = Color.white; }
        if(PlayerIdentity.activeMaskEnum == MaskTypes.Lust) { myimage = MaskImages[0].GetComponent<Image>();myimage.color = Color.red;} else { MaskImages[0].GetComponent<Image>().color = Color.white; }
        if (PlayerIdentity.activeMaskEnum == MaskTypes.Wrath) { myimage = MaskImages[3].GetComponent<Image>();myimage.color = Color.red;} else { MaskImages[3].GetComponent<Image>().color = Color.white; }
        if (PlayerIdentity.activeMaskEnum == MaskTypes.Coward) { myimage = MaskImages[1].GetComponent<Image>();myimage.color = Color.red;} else { MaskImages[1].GetComponent<Image>().color = Color.white; }


    }

}
