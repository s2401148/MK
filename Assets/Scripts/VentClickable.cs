using UnityEngine;

public class VentClickable : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerControllerTopDown player = FindObjectOfType<PlayerControllerTopDown>();
        player.ClickedOnVent(GetComponent<VentNode>());
    }
}
