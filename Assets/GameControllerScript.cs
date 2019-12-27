using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreTextElement;

    public UnityEngine.UI.Button startButton;

    public GameObject menu;

    private bool isStarted;

    protected int score = 0;

    public bool getIsStarted()
    {

        return isStarted;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTextElement.text = "Score: 0";

        startButton.onClick.AddListener(delegate { isStarted = true; menu.SetActive(false); });
    }

    public void increaseScore(int increment)
    {
        score += increment;
        scoreTextElement.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
