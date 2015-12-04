using UnityEngine;
using System.Collections;

public class GenerateEnemies : MonoBehaviour
{

    public Transform enemyPrefab;
    public float generateRate = 0.25f;

    private float enemyCooldown;



    // Use this for initialization
    void Start()
    {
        enemyCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCooldown > 0)
        {
            enemyCooldown -= Time.deltaTime;
        }
    }

    void createNewEnemy()
    {
        enemyCooldown = generateRate;

        // Create a new shot
        var enemyCreate = Instantiate(enemyPrefab) as Transform;

        // Assign position
        enemyCreate.position = transform.position;
    }

    public bool CanAttack
    {
        get
        {
            return enemyCooldown <= 0f;
        }
    }
}

