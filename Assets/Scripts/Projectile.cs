using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;

    // This is the type of entity that created the projectile.
    // The projectile is allowed to pass through this entity
    [SerializeField] public string SourceTag;


    // Note: everything that is serialized
    // is required in *copies* of a projectile
    [SerializeField] public float LifeTime = 5.0f;
    [SerializeField] public int Damage = 1;
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

    public void setLifetimeAndDamage(float weaponLifetime, int weaponDamage)
    {
        LifeTime = weaponLifetime;
        Damage = weaponDamage;
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
