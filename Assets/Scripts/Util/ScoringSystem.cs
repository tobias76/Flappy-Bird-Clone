using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoringSystem : MonoBehaviour
{

    // The players score
    public static int score = 0;

    Text text;

    public void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
