using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public int score;
    public Text scoreText;
    [SerializeField]
    private GameObject Canvas;
    Scene scene;

    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        score = 0;
        DontDestroyOnLoad(this.gameObject);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("Score: " + score);
        scene = SceneManager.GetActiveScene();
        CheckScene();
    }

    void CheckScene()
    {
        if (scene.name == "Game" )
        {
            //Canvas.SetActive(false);
        }
        //if (scene.name == "scene1" || scene.name == "scene2" || scene.name == "scene3")
        //{
        //    Canvas.SetActive(false);
        //}
        //else if (scene.name == "charselect" || scene.name == "uitleg" || scene.name == "credits" || scene.name == "Menutest")
        //{
        //    Canvas.SetActive(false);
        //    score = 0;
        //}
        //else if (scene.name == "level2" || scene.name == "level3")
        //{
        //    Canvas.SetActive(true);
        //}
        //else if (scene.name == "level1")
        //{
        //    Canvas.SetActive(true);
        //}
    }

}


