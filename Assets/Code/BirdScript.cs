using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;

    public SpriteRenderer birdSprite;
    public bool birdIsAlive;
    public float birdHeight;
    public float birdWidth;

    // Start is called before the first frame update
    void Start()
    {
        birdHeight = birdSprite.bounds.size.x / 2;
        birdWidth = birdSprite.bounds.size.y / 2;
        birdIsAlive = true;

        logic = GameObject.FindGameObjectWithTag("Score").GetComponent<LogicScript>();
        logic.InitializeHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds();

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void CheckOutOfBounds()
    {
        var birdUpperVerticalPosition = myRigidbody.transform.position.y + birdHeight;
        var birdLowerVerticalPosition = myRigidbody.transform.position.y - birdHeight;

        // TODO: - Make generic
        if ((birdUpperVerticalPosition < -13) || (birdLowerVerticalPosition > 14))
        {
            EndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void EndGame()
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
