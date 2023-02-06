using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 4f;
    }
    private void Update()
    {
        float speed = GameManager.Instance.gameSpeed;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
