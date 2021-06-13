using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveManager : MonoBehaviour
{
    public static LoveManager instance;
    public List<LoverDetails> loverDetails = new List<LoverDetails>();
    public Queue<LoverDetails> loverDetailsUnused = new Queue<LoverDetails>();
    public List<LoverDetails> loverDetailsInGame = new List<LoverDetails>();

    public List<Lover> loverObjectsInScene = new List<Lover>();

    public int maxLovers = 2;
    void Awake()
    {
        instance = this;
        loverDetailsUnused = new Queue<LoverDetails>(loverDetails);
    }
    void Start()
    {
        StartCoroutine("Spawner");
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            if (loverObjectsInScene.Count < maxLovers)
            {
                SpawnNewLovers();
            }
            yield return new WaitForSeconds(25);
        }
    }

    public void SpawnNewLovers()
    {

        int _randomInt = Random.Range(0, loverDetailsUnused.Count);
        LoverDetails first = loverDetailsUnused.Dequeue();
        LoverDetails second = loverDetailsUnused.Dequeue();
        loverDetailsInGame.Add(first);
        loverDetailsInGame.Add(second);
        int x, y;
        bool isMid = true;
        do
        {
            x = Random.Range(0, GridHandler.GridSize.x);
            y = Random.Range(0, GridHandler.GridSize.y);

            if (x == 0 || x == GridHandler.GridSize.x)
            {
                isMid = false;
            }
            if (y == 0 || y == GridHandler.GridSize.y)
            {
                isMid = false;
            }

        } while (isMid == true);

        int x2 = GridHandler.GridSize.x - x;
        int y2 = GridHandler.GridSize.y - y;

        Lover firstObject = Instantiate(first.prefab);
        Lover secondObject = Instantiate(second.prefab);


        loverObjectsInScene.Add(firstObject);
        loverObjectsInScene.Add(secondObject);

        first.Init(x, y, firstObject);
        second.Init(x2, y2, secondObject);

        secondObject.other = firstObject;
        firstObject.other = secondObject;


    }



    public void DestroyLovers(Lover a)
    {
        if (loverObjectsInScene.Contains(a))
        {
            Lover b = a.other;
            loverObjectsInScene.Remove(a);
            loverObjectsInScene.Remove(b);
            loverDetailsUnused.Enqueue(a.details);
            loverDetailsUnused.Enqueue(b.details);
            loverDetailsInGame.Remove(a.details);
            loverDetailsInGame.Remove(b.details);
        }
    }


}
