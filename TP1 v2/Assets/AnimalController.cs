using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Destroy if below screen
        if (transform.position.y < -6f)
        {
            Debug.Log("Animal escaped! Game Over trigger will go here.");
            Destroy(gameObject);
        }
    }
}
