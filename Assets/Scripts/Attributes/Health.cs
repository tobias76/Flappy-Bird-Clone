using UnityEngine;
using System.Collections;

/// <summary>
/// This class will handle damage and hit points
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// Variable declaration
    /// </summary>
    public int healthPoints = 1;
    public bool isEnemy = true;

    /// <summary>
    /// This section inflicts the damage and checks to see  if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>

    public void damage(int damageCount)
    {
        healthPoints -= damageCount;

        if (healthPoints <= 0)
        {
            //The player is dead!
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Death on collision with enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            // This restarts the game on the players death
            Application.LoadLevel(Application.loadedLevel);

        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        Shooter shot = otherCollider.gameObject.GetComponent<Shooter>();

        //If the shot doesn't exist
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                damage(shot.shotDamage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
}
