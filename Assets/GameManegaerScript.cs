using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegaerScript : MonoBehaviour
{

   // int[] map;

    int[,] map2;
    public GameObject playerPrefab;
    GameObject[,] field;

    
    /*
    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    */
    Vector2Int GetPlayerIndex()
    {
        for (int i = 0; i < map2.Length; i++)
        {
            for (int x = 0; x < map2.Length; x++)
            {
                if (field[i, x] != null && field[i,x].tag=="Player")
                {
                    return new Vector2Int(x,i);

                }
            }
        }
        return new Vector2Int(-1,-1);
    }
    
    bool MoveTag(string Tag,Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)){return false;}
        if (moveTo.x < 0 || moveTo.y >= field.GetLength(1)) { return false; }


        if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag=="Box"){
            Vector2Int velocity = moveTo - moveFrom;
            //
            bool success = MoveTag(tag, moveTo, moveTo + velocity);
            //
            if (!success) { return false; }
        }
        //プレイヤー移動
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    
    void PrintArray2()
    {
        string debugText = ",";
        for(int y = 0; y < map2.GetLength(0); y++)
        {
            for(int x = 0; x < map2.GetLength(1); x++)
            {
                debugText += map2[y, x].ToString() + ",";
            }
            debugText+="\n";
        }
        Debug.Log(debugText);
    }

    Vector3 CheckPlayerPos()
    {
       
        for (int y = 0; y < map2.GetLength(0); y++)
        {
            for (int x = 0; x < map2.GetLength(1); x++)
            {
                if (map2[y, x] == 1)
                {
                    return new Vector3(x*2, y*2, 0);
                }
            }
        }
        return new Vector3(0, 0, 0);
    }
   

    // Start is called before the first frame update
    void Start()
    {
        //GameObject instance = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0};

        map2 = new int[,]
        {
            {0,0,0,0,0 },
            {0,0,1,0,0 },
            {0,0,0,0,0 }
        };

        for(int y = 0; y < map2.GetLength(0); y++)
        {
            for(int x = 0; x < map2.GetLength(1); x++)
            {
                if (map2[y, x] == 1)
                {
                    GameObject instance = Instantiate(playerPrefab, new Vector3(x, map2.GetLength(0) - y, 0), Quaternion.identity);

                }
            }
        }


        /*
        field = new GameObject[
            map2.GetLength(0),
            map2.GetLength(1),
        ];
        */
        //
        //PrintArray();
        PrintArray2();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           Vector2Int playerIndex = GetPlayerIndex();
            // MoveNumber(1, playerIndex, playerIndex + 1);
            //文字出力
            // PrintArray();

           

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          //int playerIndex = GetPlayerIndex();
            //MoveNumber(1, playerIndex, playerIndex -1);
            //文字出力
           // PrintArray();
        }

        for (int y = 0; y < map2.GetLength(0); y++)
        {
            for (int x = 0; x < map2.GetLength(1); x++)
            {
                if (map2[y, x] == 1)
                {
                    field[y, x] = Instantiate(playerPrefab, new Vector3(x, map2.GetLength(0) - y, 0), Quaternion.identity);
                }
            }
        }
        //GameObject instance = Instantiate(playerPrefab, CheckPlayerPos(), Quaternion.identity);
    }
}
