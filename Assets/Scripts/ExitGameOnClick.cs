using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitGameOnClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Chuột trái
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Kiểm tra xem object được click có tên là "exit"
                if (hit.collider.gameObject.name == "exit")
                {
                    // Thoát game
                    Application.Quit();

#if UNITY_EDITOR
                    EditorApplication.isPlaying = false; // Dừng play mode trong Editor
#endif
                }
            }
        }
    }
}
