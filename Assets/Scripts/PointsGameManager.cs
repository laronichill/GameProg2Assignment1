using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGameManager : MonoBehaviour
{
    public int points;
    public Text pointsN;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        pointsN.text = "" + points;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            points += 10;
            Destroy(other.gameObject);
        }
    }
}
