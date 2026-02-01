using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject ParentPanel;
    public void OnButtonClick()
    {
        ParentPanel.SetActive(false);
    }
}
