using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;

    public float nextLaunch; // следующий запуск астероида

    public float minDelay, maxDelay;

    protected GameControllerScript gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameControllerScript.getIsStarted())
        {
            return;
        }

        if (Time.time > nextLaunch)
        {
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            var halfWidth = transform.localScale.x / 2;
            var positionX = Random.Range(-halfWidth, halfWidth);

            var newAsteroidPosition = new Vector3(positionX, transform.position.y, transform.position.z);

            Instantiate(asteroid, newAsteroidPosition, Quaternion.identity);
        }
    }
}
