using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeEnemyMovement : MonoBehaviour
{

    Rigidbody2D rigidbody;

    // Determining monster detection range
    [SerializeField] public float BigRange = 8f;
    [SerializeField] public float SmallRange = 3f;

    // enemy distance from player
    float distance;

    // the direction from the enemy -> player
    Vector2 direction;

    Entity player;
    Entity entity;

    void Start(){
        player = Player.Instance;
        entity = GetComponent<Entity>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if player is dead, do nothing
        if (!player) return;
        
        // finding distance to player
        var playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        distance = Vector2.Distance(playerPosition, rigidbody.position);

        // If the distance between the player and enemy is less than the detection range
        // and greater than attack range
        if ((distance < BigRange) && (distance > SmallRange))
        {
            // Finds the direction from the enemy to player (vector math, subtract player - enemy
            // to find a vector pointing from the enemy towards the player
            direction = (playerPosition - rigidbody.position).normalized;
            // changes enemy velocity to point in the right direction scaled by MovementSpeed
            rigidbody.linearVelocity = direction * entity.MovementSpeed;
        } else
        {
            // if the player isn't in range, the enemy stops moving
            rigidbody.linearVelocity = Vector2.zero;
        }
    }
}

