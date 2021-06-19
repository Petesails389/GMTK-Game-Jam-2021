using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IGridMover
{

    public Vector2Int startNodePosition;
    [SerializeField] float timeBetweenNodes = 0.5f;
    [SerializeField] bool canMoveBack;
    public bool stopMovingWhenDone = false;
    Vector2Int lastNodeLocation;
    Vector2Int currentNodeLocation;
    Vector2 currentWorldPosition;
    Vector2Int nextNodeLocation;
    Vector2Int[] directions = { Vector2Int.left, Vector2Int.down, Vector2Int.right, Vector2Int.up };



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

    public void Init()
    {
        currentNodeLocation = startNodePosition;
        transform.position = GridHandler.grid.GetNode(currentNodeLocation).worldPosition;
        StartMoving();
    }
    void OnDestroy()
    {
        StopAllCoroutines();
    }


    public float GetSpeed()
    {
        return timeBetweenNodes;
    }

    IEnumerator MoveBetweenNodes()
    {
        while (!stopMovingWhenDone)
        {
            bool findNewLocation = false;
            Node _currentNode = GridHandler.grid.GetNode(currentNodeLocation.x, currentNodeLocation.y);

            Vector2Int _nextNodeLocation;
            do
            {
                int _randomInt = Random.Range(0, _currentNode.neighbours.Count);
                _nextNodeLocation = _currentNode.neighbours[_randomInt].gridLocation;

                //Check if link to next node is not blocked
                // if (GridHandler.grid.GetLink(lastNodeLocation, _nextNodeLocation).IsBlocked)
                // {

                //     findNewLocation = true;
                // }

                //Check if can move back and next node is not back
                if (!canMoveBack && lastNodeLocation == nextNodeLocation)
                {
                    // findNewLocation = true;
                }

            } while (findNewLocation);

            nextNodeLocation = _nextNodeLocation;


            MoveToNextNodePosition();
            yield return new WaitForSeconds(timeBetweenNodes);
            lastNodeLocation = currentNodeLocation;
            currentNodeLocation = nextNodeLocation;
        }

    }

    public void SetSpeed(float _timeBetweenNodes)
    {
        timeBetweenNodes = _timeBetweenNodes;
    }

    public void MoveToNextNodePosition()
    {
        LeanTween.move(gameObject, GridHandler.grid.GetNode(nextNodeLocation).worldPosition, timeBetweenNodes);

    }


}
