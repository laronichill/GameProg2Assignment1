using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PointsGameManager : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private const string Coin = "Coin";
    private const string BlueCoinTag = "BlueCoinTag";

    public static PointsGameManager Instance { get; private set; }
    public int points = 0;
    public int WinGamePointCount = 400;
    public int pointIncrease = 50;
    public Text pointsN;
    public Text DoubleJumpedText;
    public Movement movementScript;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Set this object as the player
        gameObject.tag = PlayerTag;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (pointsN != null)
        {
            pointsN.text = points.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Coin))
        {
            points += pointIncrease;
            pointsN.text = points.ToString();

            if (points > WinGamePointCount) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            Destroy(other.gameObject);

        } else if (other.CompareTag(BlueCoinTag)) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Movement movement = player.GetComponent<Movement>();
            if (movement != null)
            {
                movement.canDoubleJumped = true; // Modify the variable
                if(movement.canDoubleJumped){
                    DoubleJumpedText.text = "YES!";
                } else {
                    DoubleJumpedText.text = "No";
                }
            }
            Destroy(other.gameObject);
        }
    }
}
