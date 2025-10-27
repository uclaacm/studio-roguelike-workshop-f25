using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] public float ShootingSpeed = 5;
    [SerializeField] public float ShootingCooldown = 1;
    [SerializeField] public int ProjectileDamage = 1;
    [SerializeField] public float ProjectileLifetime = 5;
    [SerializeField] public float ProjectileScale = 1;

    float lastShotTime;

    // Start is called before the first frame update
    void Start()
    {
        // So the player can shoot immediately upon loading in
        lastShotTime = -ShootingCooldown - 1;
    }

    // pew pew, called by Enemy or Player Attack scripts
    public void Shoot(Vector2 direction)
    {
        // Check cooldown:
        if (Time.time - lastShotTime <= ShootingCooldown) return;
        // Load in a projectile
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Init(
            ProjectileLifetime,
            ProjectileDamage,
            gameObject.tag,
            direction * ShootingSpeed,
            Vector2.one * ProjectileScale
        );
        // Reset last shot time
        lastShotTime = Time.time;
    }

}
