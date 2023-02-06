using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f * 6f; // real life gravity times some number
    public float jumpForce = 20f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();

    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            { 
                direction = Vector3.up * jumpForce;
            }

        } else
        {
            direction += Vector3.down * gravity * Time.deltaTime;
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }


}
