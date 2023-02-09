using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthAmount = 4;
    public float invincibilityTime = 1f;
    public float timerH;
    public bool invincible = false;
    private float newDamage = 0;

    public GameObject deathParticle;

    public AudioSource breakAudio;
    public AudioSource hitAudio;
 
    public SpriteRenderer spriteRenderer;
    public Sprite hitOnce;
    public Sprite hitTwice;
    public Sprite hitThrice;


    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 4f;
        deathParticle = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(invincible == true)
        {
            timerH += Time.deltaTime;

            if(timerH > invincibilityTime)
            {
                invincible = false;
                timerH = 0f;
                print("We are vulnerable now.");
            }

        }






    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (healthAmount == 3)
        {
            hitAudio.Play();
            spriteRenderer.sprite = hitOnce;
        }
        if (healthAmount == 2)
        {
            hitAudio.Play();
            spriteRenderer.sprite = hitTwice;
        }
        if (healthAmount == 1)
        {
            hitAudio.Play();
            spriteRenderer.sprite = hitThrice;
        }
        if (healthAmount == 0)
        {
            Debug.Log("Destroyed");

            Die();
        }

    }

    public void TakeDamage(float damage)
    {
        
        if (invincible == false)
        {
            healthAmount = healthAmount - damage;
            invincibilityTimer();
            invincible = true;
            
            print("Took Damage successfully");
        }
        if (invincible == true)
        {
            print("We are being hit, but are invincible");
            newDamage = damage * 0;
            healthAmount = healthAmount - newDamage;            
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AttackRange")
        {
            Debug.Log("Attacked by Collider2D");
            TakeDamage(1);
        }
    }

    public IEnumerator invincibilityTimer()
    {
        makeVulnerable();
        yield return new WaitForSeconds(1f);        
    }

    void makeVulnerable()
    {
        invincible = false;
        print("Invincibility has worn off.");
    }

    public void Die()
    {
        //ParticleSystem _ps = Instantiate(deathParticle, gameObject.transform.position, transform.position);
        deathParticle.SetActive(true);
        breakAudio.Play();
        Destroy(gameObject, 1);

    }



}
