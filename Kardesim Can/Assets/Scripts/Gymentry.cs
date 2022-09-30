using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gymentry : MonoBehaviour
{
    
    public GameObject textObj;
    public AudioSource ammansound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textObj.SetActive(true);
            
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("Info");
            ammansound.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            ammansound.Stop();
        }
    }

    IEnumerator Info()
    {
        yield return new WaitForSeconds(7f);
        textObj.SetActive(false);
    }
}
