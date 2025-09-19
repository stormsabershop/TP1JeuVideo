using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 7f;
    private PlayerController playerControllerScript;
    public float downBound = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (transform.position.x < downBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
