using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = -9.8f;

    private float velocity = 0f;

    public float max_velocity = 10f;

    public float max_rotation_angle = 55f;

    public PlayerControls playerControlls;

    public float jumpStrength = 5f;

    private AudioSource audioSource;

    private void Awake()
    {
        playerControlls = new PlayerControls();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnFlap(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void Jump()
    {
        velocity = jumpStrength;
        audioSource.Play();
    }

    private void OnEnable()
    {
        playerControlls.Enable();
        playerControlls.Gameplay.Jump.performed += OnFlap;
    }

    private void OnDisable()
    {
        playerControlls.Gameplay.Jump.performed -= OnFlap;
        playerControlls.Disable();
    }

    private void Update()
    {
        ApplyGravity();

        Rotate();

        transform.position += Vector3.up * velocity * Time.deltaTime;
    }

    private void ApplyGravity()
    {
        velocity = Mathf.Clamp(velocity + gravity * Time.deltaTime, -max_velocity, max_velocity);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, (velocity / max_velocity) * max_rotation_angle);
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        Jump();
    }
}
