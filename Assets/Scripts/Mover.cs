using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector2Int startPosition;

    Vector2Int lastPosition;
    public Vector2Int nextPos;

    void Start()
    {
        transform.position = ((Vector3Int)startPosition);
        StartCoroutine("MoveBetweenNodes");
    }

    public void Stop()
    {
        LeanTween.cancel(gameObject);
        StopAllCoroutines();
    }

    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -8));
        lineRenderer.SetPosition(1, new Vector3(nextPos.x, nextPos.y, -8));
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    IEnumerator MoveBetweenNodes()
    {
        Vector2Int _currentPos = startPosition;


        for (int i = 0; i < 50; i++)
        {

            Node _node = GridHandler.grid.GetNode(_currentPos.x, _currentPos.y);

            nextPos = lastPosition;
            while (lastPosition == nextPos)
            {
                int _randomInt = Random.Range(0, _node.neighbours.Count);
                nextPos = _node.neighbours[_randomInt].gridLocation;
            }

            lastPosition = _currentPos;
            _currentPos = nextPos;
            LeanTween.move(gameObject, ((Vector3Int)nextPos), 0.5f);
            // transform.position = ((Vector3Int)_pos);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
