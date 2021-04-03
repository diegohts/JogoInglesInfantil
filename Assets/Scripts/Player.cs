using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("Player Parameters")]
    public float speed = 5f; 
    public float jumpForce = 600f; 
    public float damageTime = 1f; 

    private Animator anim;
    private Rigidbody2D rb2d;
    private bool facingRight = true; 
    private bool jump = false; 
    private bool onGround = false; 
    public Transform groundCheck;
    private float hForce = 0; 
    private bool tookDamage = false; 
    private bool doubleJump;

    public int health; 
    public int maxhealth; 
    private int healthTemp;
   
    GameManager gameManager; 
    
    [Header("AudioAttack Variables")]
    public AudioClip deathSound;
    public AudioClip coinSound;
    private AudioSource audioS;

    [Header("Attack Variables")]
    public static bool attacking;
    public float attackTime;
    private float attackCounter;
    public GameObject sword;
    public int damage;

    private bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        groundCheck = gameObject.transform.Find("GroundCheck"); 

        anim = GetComponent<Animator>(); 
        gameManager = GameManager.gameManager; 

        SetPlayerStatus(); 
        health = maxhealth; 

        UpdateHealthUI();  

        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead) {  
            onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 
            if (onGround) {
                anim.SetBool("Jump", false); 
                doubleJump = false;
            }

            if (CrossPlatformInputManager.GetButtonDown("Jump") && (onGround || !doubleJump)) { 
                jump = true;
                if (!doubleJump && !onGround) {
                    doubleJump = true;
                }
            }

            if (!attacking) {
                sword.GetComponent<BoxCollider2D>().enabled = false;
                if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
                    sword.GetComponent<BoxCollider2D>().enabled = true;
                    attackCounter = attackTime;
                    anim.SetBool("Attack", true);
                    attacking = true;
                }
            }

            if (attackCounter > 0) {
                attackCounter -= Time.deltaTime;
            }

            if (attackCounter <= 0) {
                attacking = false;
                anim.SetBool("Attack", false);
            }

            if (onGround) {
                hForce = 0; 
            }
        }
    }

    private void FixedUpdate() 
    {
        if (!isDead) {  
            hForce = CrossPlatformInputManager.GetAxis("Horizontal"); 
            anim.SetInteger("Speed", (int)hForce);  
            rb2d.velocity = new Vector2(hForce * speed, rb2d.velocity.y);
            
            if (hForce > 0 && !facingRight) {
                Flip();
            } else if (hForce < 0 && facingRight) {
                Flip();
            }

            if (jump) { 
                anim.SetBool("Jump", true);
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
                jump = false;
            }
        }
    }

    void Flip()
    { 
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale; 
        scale.x *= -1; 
        transform.localScale = scale; 
    }

    public void SetPlayerStatus()
    { 
        maxhealth = gameManager.health;     
    }

    void UpdateHealthUI() 
    {
        FindObjectOfType<UIManager>().UpdateHealthUI(health); 
    }

    void UpdateCoinsUI()
    {
        FindObjectOfType<UIManager>().UpdateCoins(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.CompareTag("Enemy") && !tookDamage && !attacking) {  
            StartCoroutine(TookDamage()); 
        } else if (attacking) {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.tookDamage(damage);
            }
        } else if (other.CompareTag("Destroyer")) {
            tookDamage = true; 
            health -= 1; 
            healthTemp = health;
            UpdateHealthUI(); 
            isDead = true;
            anim.SetTrigger("Death");
            audioS.clip = deathSound;
            audioS.Play();
            Invoke("ReloadScene", 1f); 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !tookDamage) {
            StartCoroutine(TookDamage()); 
        } else if (other.gameObject.CompareTag("Coin")) { 
            Destroy(other.gameObject);
            gameManager.coins += 1; 
            audioS.clip = coinSound;
            audioS.Play();
            UpdateCoinsUI(); 

            if (gameManager.coins >= 100) {
                if (health < 5) {
                    health++;
                }
                UpdateHealthUI();
                SetPlayerStatus(); 
                gameManager.coins -= 100;
                FindObjectOfType<UIManager>().UpdateCoins();   
            }
        }
    }

    IEnumerator TookDamage()
    {
        tookDamage = true; 
        health--; 
        UpdateHealthUI(); 

        if (health <= 0) { 
            isDead = true;
            anim.SetTrigger("Death");
            audioS.clip = deathSound;
            audioS.Play();
            Invoke("ReloadScene", 1f); 
        } else {
            Physics2D.IgnoreLayerCollision(9, 10); 

            for (float i = 0; i < damageTime; i += 0.2f) { 
                GetComponent<SpriteRenderer>().enabled = false; 
                yield return new WaitForSeconds(0.1f); 
                GetComponent<SpriteRenderer>().enabled = true; 
                yield return new WaitForSeconds(0.1f);    
            }

            Physics2D.IgnoreLayerCollision(9, 10, false); 
            tookDamage = false;
        }
    }

    void ReloadScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void SetHealth(int life)
    {
        health += life; 
        if (health >= maxhealth) { 
            health = maxhealth;
        }

        UpdateHealthUI();
    }
}