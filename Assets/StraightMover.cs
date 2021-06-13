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
    Vector2Int currentNodePosition;
    Vector2 currentWorldPosition;
    Vector2Int nextNodePosition;

    //Interface impl.
    public void StartMoving(Vector2Int _startNodeLocation)
    {
        startNodeLocation = _startNodeLocation;
        currentNodePosition = _startNodeLocation;
        transform.position = GridHandler.grid.GetWorldPosition(currentNodePosition);
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
            Node _node = GridHandler.grid.GetNode(currentNodePosition.x, currentNodePosition.y);

            nextNodePosition = currentNodePosition + direction;
            // if (GridHandler.grid.GetLink(lastNodePosition, nextNodePosition).IsBlocked)
            // {
            //     if (turnAroundWhenBlocked)
            //     {
            //         Debug.Log("Turning around");
            //         direction *= -1;
            //         nextNodePosition = currentNodePosition + direction;
            //     }
            // }

            if (!GridHandler.grid.doesExist(nextNodePosition)){
                EndOfGridEvent.Invoke();
                stopMovingWhenDone = false;
            }

            MoveToNextNodePosition();
            lastNodePosition = currentNodePosition;
            currentNodePosition = nextNodePosition;
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
