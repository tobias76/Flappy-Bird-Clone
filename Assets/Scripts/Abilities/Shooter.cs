using UnityEngine;
using System.Collections;

/// <summary>
/// This class is where I keep all generic behaivour to do with shooting
/// </summary>
public class Shooter : MonoBehaviour
{

    /// <summary>
    /// Variable declaration
    /// </summary>

    public int shotDamage = 1;
    public bool isEnemyShot = false;

	// Use this for initialization
	void Start ()
    {
        // This section destroys shots after a 20 seconds to avoid a memory leak
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
