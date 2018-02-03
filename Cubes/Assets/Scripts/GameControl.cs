using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public Text timeText;
    public GameObject exampleCube;
    public GameObject[] cubes = new GameObject[10];

    public GameObject startUI;
    public GameObject mainUI;

    bool cubesOn = false;
    int currentCube =0;
    Vector3 spawnPos;
    System.DateTime holdTime;
	// Use this for initialization
	void Start ()
    {
        StoreTime(true);
        spawnPos = exampleCube.transform.position;
    }

    private void Awake()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = Instantiate(exampleCube, exampleCube.transform.position, exampleCube.transform.rotation);
        }
    }


    void Update()
    {
        timeText.text = System.DateTime.UtcNow.ToString("T");
        if (holdTime<= System.DateTime.UtcNow)
        {
            Spawn();
            StoreTime();
        }
    }

    void StoreTime(bool first = false)
    {
        holdTime = System.DateTime.UtcNow;
        if (first&& (holdTime.Second % 2 != 0))
        {
            holdTime = holdTime.AddSeconds(1);
        }
        else
        {
            holdTime = holdTime.AddSeconds(2);
        }


        
    }

    void Spawn()
    {        
        spawnPos.x += exampleCube.transform.localScale.x+0.2f;
        cubes[currentCube].transform.position = spawnPos;

        if (!cubesOn)
        {
            
            cubes[currentCube].SetActive(true);
        } 

        currentCube++;
        if (currentCube >= cubes.Length)
        {
            currentCube = 0;
            cubesOn = true;
        }

    }


    public void StartButtonPressed()
    {
        startUI.SetActive(false);
        mainUI.SetActive(true);
    }
}
