using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftBoundary = -10f;

    private void Start()
    {
        leftBoundary = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; 
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
