using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsGameManager : MonoBehaviour
{
    public static PointsGameManager Instance { get; private set; }
    public int points;
    public int WinGamePointCount = 50;
    public Text pointsN;

    void Start()
    {
        gameObject.tag = "Player";
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -50){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(points >= WinGamePointCount){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            points += 10;
            Destroy(other.gameObject);
            pointsN.text = "" + points;
        }
    }
}
