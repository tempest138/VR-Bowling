using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    int score;
    int frameScore;
    int step;
    int round;
    //public Text total;
    public GameObject[] pins;
    public GameObject[] frames;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        step = 0;
        round = 1;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //updateScore();
            Text currFrame = frames[step].GetComponent<Text>();
            Console.WriteLine(currFrame);
            //currFrame.text = score.ToString();
        }
    }

    bool isDown(GameObject pin)
    {
        if(pin.transform.position.y < .2f)
        {
            return true;
        }

        return false;
    }

    void updateScore()
    {
        frameScore = 0;

        foreach (GameObject p in pins)
        {
            if (isDown(p))
            {
                frameScore += 1;
            }
        }

        score += frameScore;
    }
}
