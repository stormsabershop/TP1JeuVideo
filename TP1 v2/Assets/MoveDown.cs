using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 5f;
    private PlayerController playerControllerScript;
    

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
            if(transform.rotation.y < 0)
            {
                
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else { 
                transform.Translate(Vector3.right * speed * Time.deltaTime);
             
            }
            
                
            
            
            
        }
        

    }
}
