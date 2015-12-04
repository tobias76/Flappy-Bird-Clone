using UnityEngine;
using System.Collections;

/// <summary>
/// This is where everything regarding projectile launching will be kept.
/// </summary>
public class Weapon : MonoBehaviour
{
    /// <summary>
    /// Variable declaration
    /// </summary>
    public Transform shotPrefab;

    // This is public so I can edit it if I feel it is inconsistent with how I want the game to be played
    public float shootingRate = 0.25f;

    // This is a shooting cooldown
    private float shootingCooldownRate;

	// Use this for initialization
	void Start ()
    {
        shootingCooldownRate = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shootingCooldownRate > 0)
        {
            shootingCooldownRate -= Time.deltaTime;
        }
	}

    public void Attack(bool isEnemy)
    {
        if (canAttack)
        {
            shootingCooldownRate = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            Shooter shot = shotTransform.gameObject.GetComponent<Shooter>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            Movement move = shotTransform.gameObject.GetComponent<Movement>();
            if (move != null)
            {
                move.birdVelocity.x = move.horizontalSpeed; // towards in 2D space is the right of the sprite
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool canAttack
    {
        get
        {
            return shootingCooldownRate <= 0f;
        }
    }
}
