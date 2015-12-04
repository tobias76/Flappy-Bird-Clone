using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour
{

    Transform bird;

    float offsetX;

    // Use this for initialization
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");

        // If no object has the player tag then it prints to the console
        if (playerGameObject == null)
        {
            Debug.LogError("No players found");
            return;
        }
        // This checks for any game object with the tag "Player" (This is flappy) and sets the player value as its transform
        bird = playerGameObject.transform;

        offsetX = transform.position.x - bird.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(bird != null)
        {
            Vector3 myPosition = transform.position;
            myPosition.x = bird.position.x + offsetX;
            transform.position = myPosition;
        }
    }
}
