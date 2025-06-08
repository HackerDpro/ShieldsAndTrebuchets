using UnityEngine;

public class Troop : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackPower = 10f;

    void Update()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist <= attackRange)
            {
                Destroy(enemy.gameObject);
                break;
            }
        }
    }
}