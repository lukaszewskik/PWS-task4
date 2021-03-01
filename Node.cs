using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node  
{
    public int gCost; 
    public int hCost; 
    public int fCost; 

    public Node leftNode;
    public Node bottomNode;

    public Vector3 position;

    public void SetNodePosition(int x, int y)
    {
        position = new Vector3(x, y, 0);
    }

    public void SetLeftNode(Node node)
    {
        leftNode = node;
    }

    public void SetBottomNode(Node node)
    {
        bottomNode = node;
    }

    

}
