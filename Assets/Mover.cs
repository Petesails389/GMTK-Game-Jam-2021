using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector2Int startPosition;

    int moveTweenId;

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

    IEnumerator MoveBetweenNodes()
    {
        Vector2Int _pos = startPosition;
        for (int i = 0; i < 10; i++)
        {

            Node _node = GridHandler.grid.GetNode(_pos.x, _pos.y);
            int _randomInt = Random.Range(0, _node.neighbours.Count);
            _pos = _node.neighbours[_randomInt].gridLocation;

            moveTweenId = LeanTween.move(gameObject, ((Vector3Int)_pos), 3f).id;
            // transform.position = ((Vector3Int)_pos);
            yield return new WaitForSeconds(3f);
        }

    }
}
