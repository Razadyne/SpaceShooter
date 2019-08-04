using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{    
    [Header("Movement")]
    public float movementSpeed = 1f;
    public float movementSmoothing = .1f;

    [Header("Rotation")]
    public float rotationSpeed = 4f;
    
    [HideInInspector] public Vector2 rotationDirection = Vector2.zero;
    [HideInInspector] public Vector2 movementDirection = Vector2.zero;
    [HideInInspector] public Vector2 movementVelocity = Vector2.zero;

    [HideInInspector] public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetRotationInput();
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }
    
    public virtual void GetRotationInput()
    {
        rotationDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
    
    public virtual void GetMovementInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVelocity = movementSpeed * movementDirection;
    }
    
    void Rotate()
    {
        var angle = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    
    public virtual void Move()
    {
        rb.velocity = Vector2.SmoothDamp(rb.velocity, movementDirection, ref movementVelocity, movementSmoothing);
    }
}
