using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class AnimalController : MonoBehaviour
{
    private float eatDuration = 3.21f;
    private float constantSpeed = 2.5f;
    private System.Random random = new System.Random();

    private float downBound = -50f;


    // Define the boundaries for horizontal movement
    private float leftBound = -9f;
    private float rightBound = 9f;

    private bool isHungry = true;
    private bool isEating = false;
    private bool isFleeing = false;

    private float fleeSpeed = 8f;

    private Animator animator;
    private AudioSource audioSource;

    private float startOrientation;

    private PlayerController playerControllerScript;

    private UIManager uIManager;

    

    void Start()
    {
        startOrientation = random.Next(2) == 0 ? 90f : -90f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


        transform.rotation = Quaternion.Euler(0, startOrientation, 0);

    }

    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            GererFinDuJeu();
            return;
        }

        if (isEating) return;


        if (isFleeing)
        {
            
            transform.Translate(Vector3.forward * fleeSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x) > 20f)
            {
                Destroy(gameObject);
            }
            return;
        }

        if (isHungry)
        {

            transform.Translate(Vector3.forward * constantSpeed * Time.deltaTime);

            // Check if the animal is off-screen to the left and destroy it.
            if (transform.position.x < leftBound)
            {
                Debug.Log(1);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (transform.position.x > rightBound)
            {
                Debug.Log(2);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }



           
            
        }
        if (isHungry && transform.position.z < downBound)
        {
            playerControllerScript.gameOver = true;
            Destroy(gameObject);
        }
    }

    public void Manger()
    {
        if (!isHungry) return;

        isHungry = false;
        isEating = true;

        animator.SetBool("Eat_b", true);

        uIManager.AddPoints(10);



        if (audioSource != null) audioSource.Play();

        StartCoroutine(FinirAnimal());
        
    }

    IEnumerator FinirAnimal()
    {
        yield return new WaitForSeconds(eatDuration);
        animator.SetBool("Eat_b", false);

        // Fuite activée
        isEating = false;
        isFleeing = true;

        
    }

    void GererFinDuJeu()
    {
        animator.SetBool("Eat_b", false);
        animator.SetTrigger("isSad");
    }
}

