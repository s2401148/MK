using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public EnemyAI[] enemies;                 // ✅ змінили тип
    public PlayerControllerTopDown player;    // ✅ змінили тип

    void Update()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                // Якщо потрібно, можна викликати метод SetPlayer (додай його в EnemyAI)
                // enemy.SetPlayer(player.transform);
            }
        }
    }

    public bool IsClear()
    {
        foreach (var e in enemies)
        {
            if (e != null)
                return false;
        }
        return true;
    }
}
