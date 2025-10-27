using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;

    // This is the type of entity that created the projectile.
    // The projectile is allowed to pass through this entity
    [SerializeField] public string SourceTag;
    [SerializeField] public float LifeTime;
    [SerializeField] public int Damage;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > LifeTime)
            Destroy(gameObject);
    }

    public void Init(float weaponLifetime, int weaponDamage, string sourceTag, Vector2 velocity, Vector2 scale)
    {
        LifeTime = weaponLifetime;
        Damage = weaponDamage;
        SourceTag = sourceTag;
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
        transform.localScale = scale;
    }

    // this function is called when another object enters the projectile's collider
    // and the projectile's collider is marked as a trigger
    // The parameter (other) contains information about what collided into the projectile
    // Unity documentation: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        if (other.gameObject.CompareTag(SourceTag)) return;

        Entity entity = other.GetComponent<Entity>();
        if (entity)
        {
            entity.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
