using UnityEngine;
using System.Collections.Generic;

public class VentSystemManager : MonoBehaviour
{
    public static VentSystemManager Instance;
    private List<VentNode> vents = new List<VentNode>();
    private PlayerControllerTopDown player;
    private bool isInVent = false;
    [Header("Енергія")]
    public float maxEnergy = 100f;
    public float currentEnergy;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        // Початкова енергія
        currentEnergy = maxEnergy;
    }

    // Метод для поповнення енергії
    public void RefillEnergy()
    {
        currentEnergy = maxEnergy;
        Debug.Log("⚡ Енергія поповнена до максимуму!");
    }

    void Awake() { Instance = this; }

    public void RegisterVent(VentNode vent)
    {
        if (!vents.Contains(vent))
            vents.Add(vent);
    }

    public void EnterVent(PlayerControllerTopDown playerRef)
    {
        player = playerRef;
        isInVent = true;
        player.HideInVent();
    }

    public void ExitToVent(VentNode targetVent)
    {
        if (!isInVent || player == null) return;

        player.transform.position = targetVent.transform.position;
        player.ExitVent();
        isInVent = false;
    }

}
