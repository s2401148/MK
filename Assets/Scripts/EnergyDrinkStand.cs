using UnityEngine;
using System.Collections;

public class EnergyDrinkStand : MonoBehaviour
{
    public float cooldown = 180f; // 3 хвилини
    private bool canUse = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canUse)
        {
            // Показати підказку, наприклад, "Натисни E щоб взяти енергетик"
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.GetComponent<PlayerControllerTopDown>().RefillEnergy();
                StartCoroutine(StartCooldown());
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}
