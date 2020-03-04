using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour{
    //[SerializeField] private Transform levelPart_1;
    //[SerializeField] private Transform levelPart_2;
    //[SerializeField] private Transform levelPart_3;


    [SerializeField] private Transform Player;

    [SerializeField] private Transform levelG1;
    [SerializeField] private Transform levelG2;
    [SerializeField] private Transform levelG3;
    [SerializeField] private Transform levelG4;
    [SerializeField] private Transform levelG5;
    [SerializeField] private Transform levelG6;

    Transform[] transArray;

    //public ArrayList LevelParts = new ArrayList();

    [SerializeField] private int partGapx = 128;
    [SerializeField] private int partGapy = 0;
    [SerializeField] private int startPosX = 110;

    [SerializeField] private Vector3 lastPos;

    private void Start()
    {
        SpawnLevelPart(levelG1, new Vector3(startPosX, 0));
    }

    private void Update(){
        //transArray = { levelG1, levelG2, levelG3};

        //if difference between playerx and y and last startpos == bigger than 400? ipv for loop

        //if(Player.position )

        //print("Player.position: " + Player.position);


        print("Player.position: " + Player.position.x + " lastPos: " + lastPos.x);
        if(lastPos.x - Player.position.x <= 1000)
        {
            int partGapy = Random.Range(-20, 20);
            Vector3 meep = new Vector3(partGapx, partGapy);
            SpawnLevelPart(levelG1, lastPos + meep);
        }
        

        //for (var i =0; i < 10; i++)
        //{
        //    if(i == 0)
        //    {
                
        //    }
        //    else
        //    {   
                

                
        //        //if(lastPos.x - Player.position.x <= 2000)
        //        //{
                   
        //            //SpawnLevelPart(levelG2, lastPos + meep);
        //            //SpawnLevelPart(levelG3, lastPos + meep);
        //            //SpawnLevelPart(levelG4, lastPos + meep);
        //            //SpawnLevelPart(levelG5, lastPos + meep);
        //            //SpawnLevelPart(levelG6, lastPos + meep);
        //        //}

               
        //    }
        //}
    }

    private void SpawnLevelPart(Transform part,Vector3 spawnPosition){
        //array ofzo
        Instantiate(part, spawnPosition, Quaternion.identity);
        
        lastPos = spawnPosition;
    }
    private void SpawnLevelPartPlatform(Transform part, Vector3 spawnPosition){
        Instantiate(part, spawnPosition + new Vector3(0,100), Quaternion.identity);
        //lastPos = spawnPosition;
    }


}
