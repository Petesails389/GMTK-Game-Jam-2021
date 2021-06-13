using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IGridMover
{

    [SerializeField] Vector2Int startNodePosition;
    [SerializeField] float timeBetweenNodes = 0.5f;
    [SerializeField] bool canMoveBack;
    public bool stopMovingWhenDone = false;
    Vector2Int lastNodePosition;
    Vector2Int currentNodePosition;
    Vector2 currentWorldPosition;
    Vector2Int nextNodePosition;

    //Interface impl.
    public void StartMoving()
    {
        StartCoroutine("MoveBetweenNodes");
    }

    public void StopMoving()
    {
        LeanTween.cancel(gameObject);
        StopAllCoroutines();
    }
    //Callbacks
    void Start()
    {
        currentNodePosition = startNodePosition;
        transform.position = GridHandler.grid.GetNode(currentNodePosition).worldPosition;
        StartMoving();
    }

    void Update()
    {

    }
    void OnDestroy()
    {
        StopAllCoroutines();
    }


    IEnumerator MoveBetweenNodes()
    {
        while (!stopMovingWhenDone)
        {
            Node _node = GridHandler.grid.GetNode(currentNodePosition.x, currentNodePosition.y);
            bool isBlocked = false;
            do
            {
                int _randomInt = Random.Range(0, _node.neighbours.Count);
                nextNodePosition = _node.neighbours[_randomInt].gridLocation;

                if (GridHandler.grid.GetLink(lastNodePosition, nextNodePosition).IsBlocked)
                {
                    isBlocked = true;
                }
            } while (lastNodePosition == nextNodePosition && !isBlocked);

            lastNodePosition = currentNodePosition;
            currentNodePosition = nextNodePosition;


            yield return new WaitForSeconds(timeBetweenNodes);

            MoveToNextNodePosition();

        }

    }

    public void SetSpeed(float _timeBetweenNodes)
    {
        timeBetweenNodes = _timeBetweenNodes;
    }

    public void MoveToNextNodePosition()
    {
        LeanTween.move(gameObject, GridHandler.grid.GetNode(nextNodePosition).worldPosition, timeBetweenNodes);

    }


}
