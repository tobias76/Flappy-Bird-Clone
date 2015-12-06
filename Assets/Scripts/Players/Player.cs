using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Death on collision with ground
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

            // Restarts the game on the players death
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 5 - Shooting
        bool shoot = Input.GetMouseButtonDown(0);
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

    }
}
