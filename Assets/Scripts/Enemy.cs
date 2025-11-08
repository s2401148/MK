using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int healthPoints = 2; // ворог1=2, ворог2=5
    public float speed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private Transform player;
    private float lastAttackTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            TryAttack();
        }
        else
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            player.GetComponent<PlayerControllerTopDown>().TakeHit();
            lastAttackTime = Time.time;
        }
    }

    public void TakeBulletHit()
    {
        healthPoints--;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
