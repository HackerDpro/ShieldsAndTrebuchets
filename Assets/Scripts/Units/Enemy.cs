using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float maxHealth = 100f;
    private float currentHealth;

    public float attackDamage = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private Transform target;
    private Troop troopTarget;

    // Health bar UI
    [Header("Health Bar UI")]
    public GameObject enemyHealthBarPrefab;
    private GameObject healthBarInstance;

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("PlayerBase").transform;
        // Instantiate and link health bar UI
        if (enemyHealthBarPrefab != null)
        {
            healthBarInstance = Instantiate(enemyHealthBarPrefab);
            var healthUI = healthBarInstance.GetComponent<EnemyHealthUI>();
            if (healthUI != null)
            {
                healthUI.enemy = this;
            }
        }
    }

    void Update()
    {
        if (currentHealth <= 0) return;

        if (troopTarget != null && Vector3.Distance(transform.position, troopTarget.transform.position) <= attackRange)
        {
            AttackTroop();
        }
        else if (Vector3.Distance(transform.position, target.position) > attackRange)
        {
            MoveToTarget();
        }
        else
        {
            AttackBase();
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void AttackTroop()
    {
        if (Time.time - lastAttackTime > attackCooldown)
        {
            troopTarget.TakeDamage(attackDamage);
            lastAttackTime = Time.time;
        }
    }

    void AttackBase()
    {
        // TODO: Voeg basis health en damage toe als gewenst
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
        gameObject.SetActive(false); // Verwijder vijand uit spel, kan ook Destroy(gameObject) als je wil
    }

    public float GetHealthNormalized()
    {
        return currentHealth / maxHealth;
    }

    public void SetTroopTarget(Troop troop)
    {
        troopTarget = troop;
    }

    void OnDisable()
    {
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance);
        }
    }
}