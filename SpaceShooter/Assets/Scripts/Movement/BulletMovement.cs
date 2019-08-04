using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class BulletMovement : MonoBehaviour
{    
    [Header("Movement")]
    public float movementSpeed = 1f;

    [HideInInspector] public Vector2 movementDirection = Vector2.zero;
    [HideInInspector] public Vector2 movementVelocity = Vector2.zero;

    [HideInInspector] public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        GetMovementInput();
        Move();
    }
  
    public virtual void GetMovementInput()
    {
        movementDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        movementVelocity = movementDirection * movementSpeed;
    }

    public virtual void Move()
    {
        rb.velocity = Time.deltaTime * movementSpeed * movementVelocity.normalized;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}