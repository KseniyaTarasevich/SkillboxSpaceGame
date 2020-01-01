using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject lazerGun;
    public GameObject lazerShot;
    public GameObject lazerGun2;
    public GameObject lazerGunSmall;
    public GameObject lazerShotSmall;
    public GameObject lazerGunSmall2;

    public float speed;

    public float tilt; // наклон
    public float xMin, xMax, zMin, zMax;

    public float lazerDelay; //задержка между выстрелами

    private float nextShot; //время следующего выстрела стандартной пушки (средней)
    private float nextShotSmall;


    // Start is called before the first frame update
    protected GameControllerScript gameControllerScript;

    Rigidbody ship;

    void Start()         // вызывается при создании объекта

    {
        ship = GetComponent<Rigidbody>();
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

    }

    // Update is called once per frame
    void Update()         // вызывается на каждый кадр

    {
        if (!gameControllerScript.getIsStarted())
        {
            return;
        }
        // 1. узнать, куда хочет лететь игрок

        var moveHorizontal = Input.GetAxis("Horizontal"); //куда игрок хочет лететь по горизонтали, -1...1
        var moveVertical = Input.GetAxis("Vertical");

        // 2. полететь туда

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        // 3. наклон

        ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt);

        // 4. ограничиваем движение корабля, чтобы он не вылетал за границы

        var xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);

        if (Input.GetButton("Fire1") && Time.time > nextShot)
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
            Instantiate(lazerShot, lazerGun2.transform.position, Quaternion.identity);
            nextShot = Time.time + lazerDelay;
        }

        if (Input.GetButton("Fire1") && Time.time > nextShotSmall)
        {
            Instantiate(lazerShotSmall, lazerGunSmall.transform.position, Quaternion.identity);
            Instantiate(lazerShotSmall, lazerGunSmall2.transform.position, Quaternion.identity);
            nextShotSmall = Time.time + lazerDelay / 4;
        }
    }
}
