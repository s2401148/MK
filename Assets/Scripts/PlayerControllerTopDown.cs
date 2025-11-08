using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    [Header("Рух")]
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Бойова система")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private int hitCount = 0; // кількість ударів від ворогів

    [Header("Вентиляція")]
    private bool isInVent = false;
    private VentNode currentVent;

    [Header("Енергія")]
    public float maxEnergy = 100f;
    public float currentEnergy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        // Початкова енергія
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        if (isInVent) return;

        // Рух
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Зайти у вентиляцію
        if (currentVent != null && Input.GetKeyDown(KeyCode.E))
        {
            VentSystemManager.Instance.EnterVent(this);
        }

        // Стрільба
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (!isInVent)
            rb.linearVelocity = moveInput * speed;
        else
            rb.linearVelocity = Vector2.zero;
    }

    // --- СТРІЛЬБА ---
    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.linearVelocity = firePoint.right * bulletSpeed;

        Destroy(bullet, 3f);
    }

    // --- ОТРИМАННЯ ШКОДИ ---
    public void TakeHit()
    {
        hitCount++;
        Debug.Log($"💢 Гравець отримав удар {hitCount}/3");

        if (hitCount >= 3)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("☠️ Гравець помер!");
        gameObject.SetActive(false);
        // Тут можна додати UI для програшу
    }

    // --- ВЕНТИЛЯЦІЯ ---
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vent"))
        {
            currentVent = collision.GetComponent<VentNode>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Vent") && currentVent == collision.GetComponent<VentNode>())
        {
            currentVent = null;
        }
    }

    public void ClickedOnVent(VentNode vent)
    {
        if (VentSystemManager.Instance != null)
            VentSystemManager.Instance.ExitToVent(vent);
    }

    public void HideInVent()
    {
        isInVent = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.linearVelocity = Vector2.zero;
    }

    public void ExitVent()
    {
        isInVent = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // --- ЕНЕРГЕТИК ---
    public void RefillEnergy()
    {
        currentEnergy = maxEnergy;
        Debug.Log("⚡ Енергія гравця повністю відновлена!");
    }
}
