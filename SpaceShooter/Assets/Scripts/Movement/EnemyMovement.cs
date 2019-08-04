using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class EnemyMovement : PlayerMovement
{
    [Header("Stop Distance From Target")]
    [SerializeField] public float _distanceFromTarget;

    public override void  GetRotationInput()
    {
        rotationDirection = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
    }

    public override void GetMovementInput()
    {
        movementDirection = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        movementVelocity = movementSpeed * movementDirection;
    }
    
    public override void Move()
    {
        if (Vector2.Distance(transform.position, movementDirection) > _distanceFromTarget)
        {
            rb.velocity = Vector2.SmoothDamp(rb.velocity.normalized, movementDirection, ref movementVelocity, movementSmoothing);
        }
    }
}
