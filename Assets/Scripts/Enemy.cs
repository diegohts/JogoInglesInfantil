using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health; //vida
    public float speed; //corrida
    public float attackDistance; //distancia pro ataque
    public GameObject coin; //objeto instanciado quando os inimigos morrerem, a moeda
    public GameObject deathAnimation; //coloca um sprite quando os inimigos morrerem

    protected Animator anim;
    protected bool facingRight = true; //verifica se esta pra esquerda ou direita
    protected Transform target; //alvo perseguido
    protected float targetDistance; //distancia do alvo
    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;

    void Awake() 
    {
        anim = GetComponent<Animator>();  
        target = FindObjectOfType<Player>().transform; 
        rb2d = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update() 
    { 
        targetDistance = transform.position.x - target.position.x; 
    }

    protected void Flip()  
    { 
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale; 
        scale.x *= -1;  
        transform.localScale = scale; 
    }

    public void tookDamage(int damage)
    {  
        health -= damage;   
        if (health <= 0) { 
            Instantiate(coin, transform.position, transform.rotation); 
            Instantiate(deathAnimation, transform.position, transform.rotation); 
            gameObject.SetActive(false); 
        } else {   
            StartCoroutine(TookDamageCouRotine());
        }
    } 

    IEnumerator TookDamageCouRotine()
    {                                    
        sprite.color = Color.red; 
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    } 
}