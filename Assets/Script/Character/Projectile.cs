using UnityEngine;

public class Projectile : DamageSource
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    private Vector3 direction;

    public override int DamageAmount { get => damage; protected set => base.DamageAmount = value; }

    public void Setup(Vector2 direction)
    {
        Destroy(this.gameObject, 3f);
        this.direction = direction;
    }

    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}