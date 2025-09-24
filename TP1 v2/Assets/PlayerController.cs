using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public bool gameOver = false;
    public float moveSpeed = 5f;
    public Animator anim;
    public float tiltAngle = 45f;
    public float tiltSpeed = 10f;

    public GameObject foodPrefab;
    public Transform firePoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Déplacement horizontal (A/D ou flèches gauche/droite)
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * moveSpeed * Time.deltaTime, Space.World);

        // Inclinaison gauche/droite
        float targetZ = move * tiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0, targetZ, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);

        // Tir (Espace)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espace pressé -> tirer nourriture");
            Instantiate(foodPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
