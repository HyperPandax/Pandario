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

    public GameObject[] allInstanciatedParts;

    List<Transform> levelParts;
    List<Vector3> levelPartsPositions;

    //public ArrayList LevelParts = new ArrayList();

    [SerializeField] private int partGapx = 128;
    [SerializeField] private int partGapy = 0;
    [SerializeField] private int startPosX = 110;

    [SerializeField] private Vector3 lastPos;

    private void Start()
    {
        SpawnLevelPart(levelG1, new Vector3(startPosX, 0));
        levelParts = new List<Transform>();
        levelPartsPositions = new List<Vector3>();
        //allInstanciatedParts = GameObject.FindGameObjectsWithTag("Wa");
    }

    private void Update(){
        print("Player.position: " + Player.position.x + " lastPos: " + lastPos.x);
        if(lastPos.x - Player.position.x <= 500)
        {
            int partGapy = Random.Range(-20, 20);
            Vector3 meep = new Vector3(partGapx, partGapy);
            //add transform to list or array
            
            SpawnLevelPart(levelG1, lastPos + meep);
            removeOutOfSight(lastPos + meep);
        }
    }
    private void removeOutOfSight(Vector3 meep)
    {
        print("removeoutdisght function vEctor3" + meep);
        levelPartsPositions.Add(meep);

        GameObject[] blub = GameObject.FindGameObjectsWithTag("RemoveOnWalk");
        GameObject wall = GameObject.Find("Wall");
        //print("blub: " + blub[0] + blub[2] + blub[3] + blub[4] + blub[5]);
        for (var i = 0; i < blub.Length; i++)
        {
            if(Player.position.x - blub[i].transform.position.x >= 500)
            {
                wall.transform.position = blub[i].transform.position;
                wall.transform.position += new Vector3(60, 60);
                Destroy(blub[i]);
               
            }
        }
        
        //{
        //    if( Player.position.x - levelPartsPositionX[i] >= 500)
        //    {
        //        print("removeOutOfSight object at" + levelPartsPositionX[i]);
        //    }
        //    //Print(levelPartsPositionX[i]);
        //}
    }

    private void SpawnLevelPart(Transform part,Vector3 spawnPosition){
        //array ofzo
        //Transform temp = 
        Instantiate(part, spawnPosition, Quaternion.identity);
        //levelParts.Add(temp);
       
        //levelParts.Add();
        //levelPartsPositionX.Add(spawnPosition.x);
        lastPos = spawnPosition;
    }
    private void SpawnLevelPartPlatform(Transform part, Vector3 spawnPosition){
        Instantiate(part, spawnPosition + new Vector3(0,100), Quaternion.identity);
        //lastPos = spawnPosition;
    }


    

}
