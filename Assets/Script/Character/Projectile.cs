using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private LayerMask mask;

    private Vector3 direction;

    public void Setup(Vector2 direction)
    {
        Destroy(this.gameObject, 3f);
        this.direction = direction;
    }

    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision c)
    {
        if ((mask.value & 1 << c.gameObject.layer) == 1 << c.gameObject.layer)
        {
            print("Apply damage");
            Destroy(this.gameObject);
        }        
    }
}