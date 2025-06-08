using UnityEngine;

public class Troop : MonoBehaviour
{
    public float maxHealth = 200f;
    private float currentHealth;

    public float attackDamage = 20f;
    public float attackRange = 3f;
    public float attackCooldown = 1.0f;
    private float lastAttackTime;

    private Enemy currentTarget;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        FindAndAttackEnemy();
    }

    void FindAndAttackEnemy()
    {
        if (currentTarget == null || currentTarget.GetHealthNormalized() <= 0)
        {
            currentTarget = FindClosestEnemyInRange();
            if (currentTarget != null)
            {
                currentTarget.SetTroopTarget(this);
            }
        }

        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (distance <= attackRange)
            {
                AttackEnemy();
            }
            else
            {
                // Beweeg naar vijand toe als je wil (optioneel)
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, Time.deltaTime * 2f);
            }
        }
    }

    Enemy FindClosestEnemyInRange()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closest = null;
        float minDist = attackRange + 1f;

        foreach (Enemy e in enemies)
        {
            if (e.gameObject.activeInHierarchy && e.GetHealthNormalized() > 0)
            {
                float dist = Vector3.Distance(transform.position, e.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = e;
                }
            }
        }
        return closest;
    }

    void AttackEnemy()
    {
        if (Time.time - lastAttackTime > attackCooldown)
        {
            currentTarget.TakeDamage(attackDamage);
            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        // TODO: laat troop verdwijnen of iets anders
    }

    public float GetHealthNormalized()
    {
        return currentHealth / maxHealth;
    }
}