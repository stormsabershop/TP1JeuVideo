using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 startPos;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
