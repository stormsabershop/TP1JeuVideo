using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 5f;
    private PlayerController playerControllerScript;
    private float downBound = -50f;
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
        if (transform.position.z < downBound)
        {
            Debug.Log("you lost");
            Destroy(gameObject);
        }

    }
}
