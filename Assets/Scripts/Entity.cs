using UnityEngine;

public class Entity : MonoBehaviour
{
    public int MaxHealth = 10;
    public int CurrentHealth;
    private bool dead = false;
    [SerializeField] public int MovementSpeed = 2;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (dead) return;

        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
}