using UnityEngine;

public class VentNode : MonoBehaviour
{
    public string ventID;
    private VentSystemManager manager;

    private void Start()
    {
        manager = FindObjectOfType<VentSystemManager>();
        manager.RegisterVent(this);
    }
}
