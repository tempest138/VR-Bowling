using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    GameObject[] pins;
    public List<Vector3> pinPos;
    public List<Quaternion> pinRot;
    private Vector3 ballPos;
    private Quaternion ballRot;
    //public Button exitBtn;
    //public Button b3;
    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        var ball = GameObject.FindGameObjectWithTag("Ball");
        //pinPos= new List<Vector3>();
        //pinRot= new List<Quaternion>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPos = getPos(pins);
        pinRot = getRot(pins);

        /*foreach(GameObject p in pins)
        {
            pinPos.Add(p.transform.position);
            pinRot.Add(p.transform.rotation);
        }*/

        ballPos = ball.transform.position;
        ballRot = ball.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            resetBall();
            resetPins(pins, pinPos, pinRot);
        }
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void resetBall()
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");
        ball.transform.position = ballPos;
        ball.transform.rotation = ballRot;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    public void resetPins(GameObject[] pins, List<Vector3> pos, List<Quaternion> rot)
    {
        //GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");
        for(int i = 0; i < pins.Length; i++)
        {
            var pin = pins[i];
            var pinPhys = pin.GetComponent<Rigidbody>();
            pin.transform.position = pos[i];
            pin.transform.rotation = rot[i];
            pinPhys.velocity = Vector3.zero;
            pinPhys.angularVelocity = Vector3.zero;
        }
    }

    public List<Vector3> getPos(GameObject[] pins)
    {
        List<Vector3> pos = new List<Vector3>();
        foreach (GameObject p in pins)
        {
            pos.Add(p.transform.position);
        }

        return pos;
    }

    public List<Quaternion> getRot(GameObject[] pins)
    {
        List<Quaternion> rot = new List<Quaternion>();
        foreach (GameObject p in pins)
        {
            rot.Add(p.transform.rotation);
        }

        return rot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pin")
        {
            GetComponent<AudioSource>().Play();
        }
    }


}
