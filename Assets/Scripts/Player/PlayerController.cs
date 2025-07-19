using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 20f;
    private Rigidbody playerRb;
    private Door currentDoor;

    public bool HasKey { get; set; } = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentDoor)
        {
            currentDoor.OpenDoor(HasKey);
        }
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) Move(Vector3.forward);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) Move(Vector3.back);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) Move(Vector3.left);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        direction.Normalize();
        Vector3 targetVelocity = direction * playerSpeed;
        playerRb.linearVelocity = Vector3.Lerp(playerRb.linearVelocity, targetVelocity, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Door door))
        {
            currentDoor = door;
            UIManager.Instance.ShowDoorMessage(HasKey ? "Press E to open the door." : "The door is locked.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Door door))
        {
            currentDoor = null;
            UIManager.Instance.HideDoorMessage();
        }
    }
}
