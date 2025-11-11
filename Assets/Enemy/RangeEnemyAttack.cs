using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour
{
    [SerializeField] float range = 3f;
    [SerializeField] float initialAttackDelay = 2;

    Weapon weapon;

    Entity player;
    float startTime;

    void Start(){
        player = Player.Instance;
        weapon = GetComponent<Weapon>();
        startTime = Time.time;
    }

    void Update(){
        // if player is dead, do nothing
        if (!player) return;

        //wait before initial attack
        if (Time.time < startTime + initialAttackDelay) return;
        
        //distance to player
        var playerPos = player.transform.position;
        var displacement = playerPos - transform.position;
        var distance = displacement.magnitude;

        //if within range, shoot
        if (distance < range)
        {
            weapon.Shoot(displacement / distance);
        }
    }
}
