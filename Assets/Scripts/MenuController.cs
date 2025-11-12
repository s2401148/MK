using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Chuột trái
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Kiểm tra xem object được click có tên là "New Game" không
                if (hit.collider.gameObject.name == "new game")
                {
                    // Load scene theo tên
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}
