using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            List<Node> nodes = AStar.GetNewPath(GridHandler.Grid.GetNode(0, 0), GridHandler.Grid.GetNode(3, 3));
            
            foreach (Node n in nodes)
            {
                Debug.Log(n.gridLocation);
            }
        }
    }
}
