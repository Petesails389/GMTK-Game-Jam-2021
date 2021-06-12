using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float cardSpawnTime;
    [SerializeField] GameObject cardPickupItem;
    private float cardSpawnTimer;
    private Vector2Int cardSpawnLocation;

    void Update()
    {
        if(cardSpawnTimer <=0){
            int _x = Random.Range(0,4);
            int _y = Random.Range(0,4);
            cardSpawnLocation = GridHandler.grid.GetNode(_x,_y).gridLocation;
            GameObject _instance = Instantiate(cardPickupItem, new Vector3(0, 0, 0), Quaternion.identity);
            LeanTween.move(_instance, ((Vector3Int)cardSpawnLocation), 0f);
            cardSpawnTimer = cardSpawnTime;
        }
        cardSpawnTimer -= Time.deltaTime;
    }
}
