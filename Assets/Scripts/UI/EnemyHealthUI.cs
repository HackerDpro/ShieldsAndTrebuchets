using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Enemy enemy;                  // Link naar vijand script
    public Slider healthSlider;          // Link naar slider component
    public Vector3 offset = new Vector3(0, 2, 0);  // Hoogte boven vijand

    void Update()
    {
        if (enemy == null || !enemy.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);        // Verwijder health bar als vijand dood is
            return;
        }

        healthSlider.value = enemy.GetHealthNormalized();

        Vector3 worldPos = enemy.transform.position + offset;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        transform.position = screenPos;
    }
}