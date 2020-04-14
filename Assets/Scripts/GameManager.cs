using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] private Text scoreText;
    public int meter;
    [SerializeField] private Text meterText;
    public int health;
    [SerializeField] private Text healthText;

    [SerializeField] private Transform dead;

    [SerializeField] private Transform player;
    private float startpos;
    [SerializeField] private GameObject Canvas;
    Scene scene;

    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        score = 0;
        meter = 0;
        health = 3;
        startpos = player.transform.position.x;
        print(startpos);
        DontDestroyOnLoad(this.gameObject);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ("Health: " + health);
        scoreText.text = ("Score: " + score);
        float meep = player.transform.position.x - startpos;
        meterText.text = ("Meter: " + Mathf.FloorToInt(meep));
        scene = SceneManager.GetActiveScene();
        //CheckScene();
    }

}
