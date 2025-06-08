using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;

    void Update()
    {
        woodText.text = "Wood: " + GameManager.Instance.resourceManager.wood;
        stoneText.text = "Stone: " + GameManager.Instance.resourceManager.stone;
    }
}