using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Horizontal input
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new(movement.x, 0, movement.y);
        // move = Vector3.Dot(move, cameraTransform.forward) * move;
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;
        move = Vector3.ClampMagnitude(move, 1f); // Optional: prevents faster diagonal movement
        // if (move != Vector3.zero)
        // {
        //     transform.position += forward = move;
        // }

        // move = Vector3.RotateTowards(move, cameraTransform.forward, math.PI, 1);
        Quaternion lookDir = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        lookDir.eulerAngles = new(0, lookDir.x, 0);
        transform.rotation = lookDir;
        Vector3 rot = transform.rotation.eulerAngles;

        // Jump
        if (inputManager.IsPlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
