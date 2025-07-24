using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource[] BGMList;
    public AudioSource BGM1;
    public AudioSource BGM2;
    public AudioSource BGM3;

    // Start is called before the first frame update
    void Start()
    {
        BGMList = GetComponents<AudioSource>();
        BGMList[Random.Range(0, BGMList.Length)].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
