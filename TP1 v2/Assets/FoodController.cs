using UnityEngine;

public class FoodController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 10f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Debug.Log("a food provided contact");
            AnimalController animal = other.GetComponent<AnimalController>();
            if (animal != null)
            {
                animal.Manger(); // appelle le script AnimalController
            }

            Destroy(gameObject); // détruire la nourriture après impact
        }
    }
}
