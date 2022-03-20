using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField]
    private float speed;

    private Vector3 direction;

    void Start() {
        Destroy(this.gameObject, 3f);
    }

    public void SetDirection (Vector2 dir) {
        this.direction = dir;
    }
    
    void Update () {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}