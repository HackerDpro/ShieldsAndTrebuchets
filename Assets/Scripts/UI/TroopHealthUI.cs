using UnityEngine;
using UnityEngine.UI;

public class TroopHealthUI : MonoBehaviour
{
    public Troop troop;              // Link naar troop script
    public Slider healthSlider;      // Link naar slider component

    void Update()
    {
        if (troop == null || !troop.gameObject.activeInHierarchy)
        {
            healthSlider.value = 0;
            return;
        }

        healthSlider.value = troop.GetHealthNormalized();
    }
}