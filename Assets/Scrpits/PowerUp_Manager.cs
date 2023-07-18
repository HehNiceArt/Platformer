using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Manager : MonoBehaviour
{
    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    private float baseMovementSpeed;

    public PlayerBehavior player;
    // Start is called before the first frame update
   //Invoke Coroutines - delay execution of script
   void Start()
    {
        baseMovementSpeed = player.movementSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            player.movementSpeed += speedBoost;
            player.anim.speed = player.movementSpeed - 6;
            Debug.Log("Increase speed! \r\n Speed Boost Power Up consumed");
            StartCoroutine(BaseSpeed());
        }
        if (health)
        {
            player.healthPoints+= healthBoost;
            Debug.Log("Increase health! HP + 10 \r\n Health Boost Power Up consumed");
        }

    }

   IEnumerator BaseSpeed()
    {
        
        yield return new WaitForSecondsRealtime(duration);
        player.movementSpeed = baseMovementSpeed;
        player.anim.speed = player.movementSpeed - 3;
        Debug.Log("Return normal animation speed");
    }
}
