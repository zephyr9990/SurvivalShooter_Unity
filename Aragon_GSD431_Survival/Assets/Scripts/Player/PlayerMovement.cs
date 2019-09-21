using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator animator;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turning();
        Animating(horizontal, vertical);
    }

    void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }
    }

    void Animating(float horizontal, float vertical)
    {
        bool walking = horizontal != 0f || vertical != 0f;
        animator.SetBool("IsWalking", walking);
    }
}
