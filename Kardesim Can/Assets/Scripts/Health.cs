using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float iFramesDuration;
    private float startingHealth = 6;
    public float currentHealth { get; private set; }
    private bool dead;
    //private Animator anim;
    private SpriteRenderer spriteRend;
  


    private void Awake()
    {

        currentHealth = startingHealth;
        //anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            StartCoroutine("Invunerability");
        }
        else
        {
            if (!dead)
            {
                //anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<MeleeAttack>().enabled = false;
                dead = true;
                SceneManager.LoadScene("GameOver");
            }    
         
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8,7,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 7, true);
    }

}
