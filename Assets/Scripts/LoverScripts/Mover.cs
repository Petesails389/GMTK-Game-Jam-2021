using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IGridMover
{
    public Vector2Int startNodeLocation;
    [SerializeField] float timeBetweenNodes = 0.5f;
    [SerializeField] bool canMoveBack;
    public bool stopMovingWhenDone = false;
    Vector2Int lastNodeLocation;
    Vector2Int currentNodeLocation;
    Vector2Int nextNodeLocation;
    Vector2Int[] directions = { Vector2Int.left, Vector2Int.down, Vector2Int.right, Vector2Int.up };

    //Interface impl.
    public void MoveToNodeLocation(Vector2Int _nodeLocation)
    {
        throw new System.NotImplementedException();
    }

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
        currentNodeLocation = startNodeLocation;

        SetPositionToNodeLocation(currentNodeLocation);
        StartMoving();
    }

    public void SetPositionToNodeLocation(Vector2Int _nodeLocation)
    {
        transform.position = GridHandler.Grid.GetNode(_nodeLocation).worldPosition;
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
            Node _currentNode = GridHandler.Grid.GetNode(currentNodeLocation.x, currentNodeLocation.y);

            Node _nextNode = _currentNode.GetRandomNeighbour();

            //Check if link to next node is not blocked
            if (GridHandler.Grid.GetLink(_currentNode, _nextNode).IsBlocked)
            {
                Debug.Log("is blocked");
                // findNewLocation = true;
            }

            //Check if can move back and next node is not back
            if (!canMoveBack && lastNodeLocation == nextNodeLocation)
            {
                // findNewLocation = true;
            }


            nextNodeLocation = _nextNode.gridLocation;


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
        LeanTween.move(gameObject, GridHandler.Grid.GetNode(nextNodeLocation).worldPosition, timeBetweenNodes);

    }


}
