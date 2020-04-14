using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour{
   
    [SerializeField] private Transform Player;

    List<Transform> coins;
    private int coinNum = 0;
    List<Vector3> levelPartsPositions;

    [SerializeField] private int partGapx = 16;
    [SerializeField] private int partGapy = 0;
    [SerializeField] private int startPosX = 64;

    [SerializeField] private int distance = 500;

    [SerializeField] private int blockCounter = 0;
    [SerializeField] private int ACounter = 0;
    [SerializeField] private int BCounter = 0;

    [SerializeField] private Vector3 lastPos;

    private Transform ground;
    private Transform platform2;
    private Transform platform3;
    private Transform platform4;
    private Transform platformThin;

    private Transform palmtree;
    private Transform tree1;
    private Transform tree2;
    private Transform tree3;
    private Transform treesBG1;
    private Transform treesBG2;
    private Transform treesBG3;

    private void Start(){
        coins = new List<Transform>();
        //load simplegroundpart
        ground = Resources.Load<Transform>("Prefabs/platforms/platform_1");
        platform2 = Resources.Load<Transform>("Prefabs/platforms/platform_2");
        platform3 = Resources.Load<Transform>("Prefabs/platforms/platform_3");
        platform4 = Resources.Load<Transform>("Prefabs/platforms/platform_4");
        platformThin = Resources.Load<Transform>("Prefabs/platforms/platform_thin");
        //load coins
        var redcoin = Resources.Load<Transform>("Prefabs/CoinRed");
        var orangecoin = Resources.Load<Transform>("Prefabs/Coinorange");
        var yellowcoin = Resources.Load<Transform>("Prefabs/CoinYellow");
        var greencoin = Resources.Load<Transform>("Prefabs/Coingreen");
        var bluecoin = Resources.Load<Transform>("Prefabs/CoinBlue");
        var purplecoin = Resources.Load<Transform>("Prefabs/CoinPurple");
        coins.Add(redcoin);
        coins.Add(orangecoin);
        coins.Add(yellowcoin);
        coins.Add(greencoin);
        coins.Add(bluecoin);
        coins.Add(purplecoin);
        //load trees
        palmtree = Resources.Load<Transform>("Prefabs/PalmTree");
        treesBG1 = Resources.Load<Transform>("Prefabs/treesblack1");
        treesBG2 = Resources.Load<Transform>("Prefabs/treesblack2");
        treesBG3 = Resources.Load<Transform>("Prefabs/treesblack3");
        tree1 = Resources.Load<Transform>("Prefabs/tree1");
        tree2 = Resources.Load<Transform>("Prefabs/tree2");
        tree3 = Resources.Load<Transform>("Prefabs/tree3");

        levelPartsPositions = new List<Vector3>();

        SpawnLevelPart(ground, new Vector3(startPosX, 0));
        Instantiate(treesBG2, new Vector3(startPosX-20,50,30), Quaternion.identity);
    }

    private void Update(){
        if(lastPos.x - Player.position.x <= distance)
        {
            Vector3 meep = new Vector3(partGapx, 0);
                       
            SpawnLevelPart(ground, lastPos + meep);
            removeOutOfSight(lastPos + meep);
        }
    }

    private void removeOutOfSight(Vector3 meep){
        levelPartsPositions.Add(meep);

        GameObject[] blub = GameObject.FindGameObjectsWithTag("RemoveOnWalk");
        GameObject wall = GameObject.Find("Wall");
       
        for (int i = 0; i < blub.Length; i++){
            if(Player.position.x - blub[i].transform.position.x >= distance){
                print(blub[i]);
                wall.transform.position = blub[i].transform.position +new Vector3(35,0,0);
                Destroy(blub[i]);
            }
        }
    }

    private void SpawnLevelPart(Transform part, Vector3 spawnPosition){
        Instantiate(part, spawnPosition, Quaternion.identity);
        SpawnTrees(spawnPosition);
        lastPos = spawnPosition;
        blockCounter++;
        ACounter++;
        BCounter++;
        if (blockCounter== 5)
        {
            Instantiate(coins[coinNum], spawnPosition + new Vector3(0,20), Quaternion.identity);
            coinNum++;
            if(coinNum >= coins.Count)
            {
                coinNum = 0;
            }
            blockCounter = 0;
        }
        if (ACounter == 8)
        {
            SpawnLow( spawnPosition);
            ACounter = 0;
        }
        if (BCounter == 18)
        {
            SpawnThin(spawnPosition);
            BCounter = 0;
        }
        
    }
   

    private void SpawnThin(Vector3 spawnPosition)
    {
        int meep = Random.Range(0, 10);
        int eep = Random.Range(40, 60);

    }
    private void SpawnLow(Vector3 spawnPosition)
    {
        int meep = Random.Range(0, 10);
        int eep = Random.Range(10, 30);
        
        if (meep== 0 || meep == 1 || meep == 2 || meep == 3){Instantiate(platform4, spawnPosition + new Vector3(-32, eep, 10), Quaternion.identity); SpawnMid(platform3, spawnPosition); }
        if (meep == 4 || meep == 5 || meep == 6 || meep == 10) { Instantiate(platform3, spawnPosition + new Vector3(-32, eep, 10), Quaternion.identity); SpawnMid(platform2, spawnPosition); }
        if (meep == 7 || meep == 8 || meep == 9) { Instantiate(platform2, spawnPosition + new Vector3(-32, eep, 10), Quaternion.identity); }          
       
    }
    private void SpawnMid(Transform part, Vector3 spawnPosition)
    {
        int beep = Random.Range(10, 20);
        int eep = Random.Range(35, 45);
        Instantiate(part, spawnPosition + new Vector3(beep, eep, 15), Quaternion.identity);
       
        int meep = Random.Range(0, 10);
        if (meep == 4 || meep == 6 || meep == 8)
        {
            SpawnHigh(part, spawnPosition);
        }
    }
    private void SpawnHigh(Transform part, Vector3 spawnPosition)
    {
        int eep = Random.Range(55, 65);
        Instantiate(platform2, spawnPosition + new Vector3(32, eep, 20), Quaternion.identity);
    }

    private void SpawnTrees(Vector3 spawnPosition)
    {
        int eep = Random.Range(0, 15);
        if(eep == 6)
        {
            Instantiate(tree3, spawnPosition + new Vector3(20, 37.5f, 0), Quaternion.identity);
        }
        if (eep == 7 || eep == 4) {
            
            Instantiate(treesBG1, spawnPosition + new Vector3(0, 65, 30), Quaternion.identity);
        }
        if (eep == 12 || eep == 9 || eep == 2)
        {
            
            Instantiate(treesBG2, spawnPosition + new Vector3(0, 50, 29), Quaternion.identity);
        }
        if (eep == 3 || eep == 11){Instantiate(tree2, spawnPosition + new Vector3(0, 50, 0), Quaternion.identity);}
        if (eep ==  1 || eep == 5) { Instantiate(treesBG3, spawnPosition + new Vector3(0, 36, 28), Quaternion.identity); }
            
    }
}
