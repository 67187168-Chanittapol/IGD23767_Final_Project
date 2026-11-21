using UnityEngine;

public class MovingObstacle : Enemy
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private Vector3 moveDirection = Vector3.right;
    [SerializeField] private float maxDistance = 40f;
    [SerializeField] private bool destroyOnHitPlayer = false;

    private Vector3 spawnPos;

    protected override void Start()
    {
        base.Start();
        spawnPos = transform.position;
        transform.forward = moveDirection;

        if (Agent != null)
        {
            Agent.enabled = false;
        }
    }

    private void Update()
    {
        transform.position += moveDirection.normalized * (moveSpeed * Time.deltaTime);

        if (Vector3.Distance(spawnPos, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    public void Setup(Vector3 direction, float speed, float distance)
    {
        moveDirection = direction.normalized;
        moveSpeed = speed;
        maxDistance = distance;
        transform.forward = moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player targetPlayer = other.GetComponent<Player>();
        if (targetPlayer != null)
        {
            Attack(targetPlayer);

            if (destroyOnHitPlayer)
            {
                Destroy(gameObject);
            }
        }
    }
}