using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour{
   
    [SerializeField] private Transform Player;

    List<Transform> levelParts;
    List<Vector3> levelPartsPositions;

    [SerializeField] private int partGapx = 128;
    [SerializeField] private int partGapy = 0;
    [SerializeField] private int startPosX = 110;

    [SerializeField] private Vector3 lastPos;

    private void Start(){
        levelParts = new List<Transform>();

        //Load all levelpart (Assets/Resources/Prefabs/levelParts)
        var part1 = Resources.Load<Transform>("Prefabs/levelParts/G1");
        levelParts.Add(part1);
        var part2 = Resources.Load<Transform>("Prefabs/levelParts/G2");
        levelParts.Add(part2);
        var part3 = Resources.Load<Transform>("Prefabs/levelParts/G3");
        levelParts.Add(part3);
        var part4 = Resources.Load<Transform>("Prefabs/levelParts/G4");
        levelParts.Add(part4);
        var part5 = Resources.Load<Transform>("Prefabs/levelParts/G5");
        levelParts.Add(part5);
        var part6 = Resources.Load<Transform>("Prefabs/levelParts/G6");
        levelParts.Add(part6);
        
        levelPartsPositions = new List<Vector3>();

        int partPiece = Random.Range(0, levelParts.Count-1);
        SpawnLevelPart(levelParts[partPiece], new Vector3(startPosX, 0));
    }

    private void Update(){
        if(lastPos.x - Player.position.x <= 500){
            int partPiece = Random.Range(0, levelParts.Count - 1);
            int partGapy = Random.Range(-20, 20);
            Vector3 meep = new Vector3(partGapx, partGapy);
                       
            SpawnLevelPart(levelParts[partPiece], lastPos + meep);
            removeOutOfSight(lastPos + meep);
        }
    }

    private void removeOutOfSight(Vector3 meep){
        print("removeoutdisght function vEctor3" + meep);
        levelPartsPositions.Add(meep);

        GameObject[] blub = GameObject.FindGameObjectsWithTag("RemoveOnWalk");
        GameObject wall = GameObject.Find("Wall");
        for (var i = 0; i < blub.Length; i++){
            if(Player.position.x - blub[i].transform.position.x >= 500){
                wall.transform.position = blub[i].transform.position;
                wall.transform.position += new Vector3(60, 60);
                Destroy(blub[i]); 
            }
        }
    }

    private void SpawnLevelPart(Transform part, Vector3 spawnPosition){
        // error
        //int partPiece = Random.Range(0, levelParts.Count -1);
        //print("partPiece: " + partPiece);
                
        //print(levelParts[0]);
        //Transform part = levelParts[0];

        Instantiate(part, spawnPosition, Quaternion.identity);
        lastPos = spawnPosition;
    }
    //private void SpawnLevelPartPlatform(Transform part, Vector3 spawnPosition){
    //    Instantiate(part, spawnPosition + new Vector3(0,100), Quaternion.identity);
    //}


    

}
