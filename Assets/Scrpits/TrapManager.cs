using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update

    public int trapDamage;
    public PlayerBehavior player;
    public bool isPlayerOnTop;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerOnTop= true;
        Debug.Log("isPlayerOnTop true");
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", true);
            Debug.Log("Activate trap");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerOnTop= false;
        Debug.Log("isPlayerOnTop false");
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", false);
            Debug.Log("Deactivate trap");
        }
    }

    public void playerDamage()
    {
        if (isPlayerOnTop)
        {
            player.healthPoints -= trapDamage;
            Debug.Log("Player HP - 15");

        }
        if (player.healthPoints <= 0 ) 
        {
            //player.gameObject.SetActive(false);
            player.healthPoints = 0;
            Debug.Log("You died!");
        }
    }
}

