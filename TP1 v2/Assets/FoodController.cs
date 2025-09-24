using UnityEngine;

public class FoodController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible()
    {
        // Unity calls this when the object leaves the camera view
        Destroy(gameObject);
    }
}
