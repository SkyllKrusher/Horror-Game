using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text countText;
    [SerializeField]
    private GameObject countParentObj;
    [SerializeField]
    private Image emptyGreyOverlay;

    public void SetItemUI(int count)
    {
        if (count <= 0)
        {
            countParentObj.SetActive(false);
            emptyGreyOverlay.enabled = true;
            return;
        }
        countParentObj.SetActive(true);
        countText.text = "" + count;
    }
}
