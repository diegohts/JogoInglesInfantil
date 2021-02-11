using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Attack : MonoBehaviour
{
    [Header("Attack Variables")]
    public static bool attacking;
    public float attackTime;
    private float attackCounter;
    public Animator animator;
    public GameObject sword;
    
    public int damage = 1;
    public bool inAttack;
    private float nextAttack;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        damage = GameManager.gameManager.damage;
    }

    private void Update()
    {
        inAttack = false;

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && Time.time > nextAttack) {
            PlayerAttack();
        }
    }

    public void PlayerAttack()
    {
        if (!attacking) {
            sword.GetComponent<BoxCollider2D>().enabled = false;
            if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
                attackCounter = attackTime;
                attacking = true;
                sword.GetComponent<BoxCollider2D>().enabled = true;
                animator.SetTrigger("Attack");
            }
        }

        if (attackCounter > 0) {
            attackCounter -= Time.deltaTime;
        }

        if (attackCounter <= 0) {
            attacking = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null) {
            inAttack = true;
            enemy.tookDamage(damage);
        }
        Destroy(gameObject);
    }
}
