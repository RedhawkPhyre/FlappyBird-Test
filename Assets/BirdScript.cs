using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject wingUpL;
    public GameObject wingDownL;
    public GameObject wingUpR;
    public GameObject wingDownR;
    private float lastY;
    private float currentY;

    // Start is called before the first frame update
    void Start()
    {
        lastY = myRigidbody.transform.position.y;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        currentY = myRigidbody.position.y;
        if (lastY < currentY)
        {
            wingUpL.SetActive(false);
            wingDownL.SetActive(true);
            wingUpR.SetActive(false);
            wingDownR.SetActive(true);

        }
        else if (lastY > currentY)
        {
            wingUpL.SetActive(true);
            wingDownL.SetActive(false);
            wingUpR.SetActive(true);
            wingDownR.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 11.2 || transform.position.y < -11)
        {
            birdIsAlive = false;
            logic.gameOver();
        }

        lastY = myRigidbody.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}