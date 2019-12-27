using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotation;

    public float minSpeed;
    public float maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    protected GameControllerScript gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;

        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid") { return; }

        Destroy(other.gameObject);
        Destroy(gameObject);

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        } else { gameControllerScript.increaseScore(10); }

        
    }
}
