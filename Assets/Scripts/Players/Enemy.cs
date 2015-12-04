using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private Weapon weapon;

    public void Awake()
    {
        //Retrieve the current weapon once
        weapon = GetComponent<Weapon>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Auto-fire
        if (weapon != null && weapon.canAttack)
        {
            weapon.Attack(true);
        }
    }
}
