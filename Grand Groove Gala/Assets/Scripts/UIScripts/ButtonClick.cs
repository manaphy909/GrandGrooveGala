using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject ParentPanel;
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        ParentPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
