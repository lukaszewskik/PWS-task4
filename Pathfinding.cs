using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Camera cam;
    Vector3 mousePosition;
    public Grid grid;
    Node endNode;
    Node startNode;
    Node previousNode;


    List<Node> openList;
    List<Node> closedList;
    


    private void OnEnable()
    {
        startNode = grid.nodes[0, 0];
        FindSuccessors(0, 1);
    }

    List<Node> FindSuccessors(int x, int y)
    {
        List<Node> successors = new List<Node>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (!(j == 0 && i == 0))
                {
                    if (x + i >= 0 && x + i <= grid.width && y + j >= 0 && y + 1 <= grid.height)
                    {
                        successors.Add(grid.nodes[x + i, y + j]);
                    }
                }                                            
            }                                           
        }
        return successors;
    }

    void FindPath()
    {
        openList = new List<Node>();
        startNode.fCost = startNode.hCost;
        openList.Add(startNode);
        closedList = new List<Node>();
        Node currentNode = startNode;
        
        while (openList.Count > 0)
        {
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost)
                {
                    currentNode = openList[i];
                }
                
            }
            if (currentNode == endNode)
            {
                break;
            }


            foreach (Node node in FindSuccessors((int)currentNode.position.x, (int)currentNode.position.y))
            {
                if (openList.Contains(node))
                {

                }
            }

        }
    }

    //void FindPath()
    //{
    //    Node currentNode;
    //    openList = new List<Node>();
    //    openList.Add(startNode);
    //    closedList = new List<Node>();
    //    for (int i = 0; i < grid.height; i++)
    //    {
    //        for (int j = 0; j < grid.width; j++)
    //        {
    //            currentNode = grid.nodes[j, i];
    //            currentNode.gCost = int.MaxValue;
    //            currentNode.fCost = currentNode.gCost + currentNode.hCost;
    //            previousNode = null;

    //        }
    //    }
    //    startNode.gCost = 0;
        

    //}

    int CalculateHCost(int x, int y)
    {
        int h = 10;
        //|xstart - x dest| + |ystart - y dest|
        return h;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x;
            int y;
            mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);
            Debug.Log(mousePosition);

            endNode = grid.nodes[(int)Mathf.Round(mousePosition.x), (int)Mathf.Round(mousePosition.y)];
            Debug.Log(endNode.position);

          
        }
       
    }


}
