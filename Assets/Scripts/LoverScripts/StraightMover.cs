using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StraightMover : MonoBehaviour
{
    public UnityEvent EndOfGridEvent;
    public Vector2Int direction;
    [SerializeField] bool turnAroundWhenBlocked;

    [SerializeField] public Vector2Int startNodeLocation;
    [SerializeField] float timeBetweenNodes = 0.5f;
    [SerializeField] bool canMoveBack;
    public bool stopMovingWhenDone = false;
    Vector2Int lastNodePosition;
    Vector2Int currentNodeLocation;
    Vector2 currentWorldPosition;
    Vector2Int nextNodePosition;

    //Interface impl.
    public void StartMoving(Vector2Int _startNodeLocation)
    {
        startNodeLocation = _startNodeLocation;
        currentNodeLocation = _startNodeLocation;
        transform.position = GridHandler.grid.GetWorldPosition(currentNodeLocation);
        if (currentNodeLocation.x < GridHandler.GridSize.x / 2)
            direction = Vector2Int.right;
        else if (currentNodeLocation.y < GridHandler.GridSize.y / 2)
            direction = Vector2Int.up;
        else if (currentNodeLocation.x > GridHandler.GridSize.x / 2)
            direction = Vector2Int.left;
        else 
            direction = Vector2Int.down;

        StartCoroutine("MoveBetweenNodes");
    }

    public void StopMoving()
    {
        LeanTween.cancel(gameObject);
        StopAllCoroutines();
    }
    //Callbacks
    void OnDestroy()
    {
        StopMoving();
    }


    IEnumerator MoveBetweenNodes()
    {
        while (!stopMovingWhenDone)
        {
            Node _node = GridHandler.grid.GetNode(currentNodeLocation.x, currentNodeLocation.y);

            nextNodePosition = currentNodeLocation + direction;
            // if (GridHandler.grid.GetLink(lastNodePosition, nextNodePosition).IsBlocked)
            // {
            //     if (turnAroundWhenBlocked)
            //     {
            //         Debug.Log("Turning around");
            //         direction *= -1;
            //         nextNodePosition = currentNodePosition + direction;
            //     }
            // }

            if (!GridHandler.grid.DoesExist(nextNodePosition))
            {
                EndOfGridEvent.Invoke();
                stopMovingWhenDone = false;
            }

            MoveToNextNodePosition();
            lastNodePosition = currentNodeLocation;
            currentNodeLocation = nextNodePosition;
            yield return new WaitForSeconds(timeBetweenNodes);
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
