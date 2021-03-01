using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Node[,] nodes;
    public int width = 8; //columns, X
    public int height = 10; //rows, Y

    
    void Start()
    {
        nodes = new Node[width, height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                nodes[j, i] = new Node();
                nodes[j, i].SetNodePosition(j, i);

                if (j>0)
                {                    
                    nodes[j, i].SetLeftNode(nodes[j - 1, i]);                    
                }

                if (i>0)
                {
                    nodes[j, i].SetBottomNode(nodes[j, i - 1]);

                }               
            }
        }
    }

  
    private void OnDrawGizmos()
    {
        if (nodes.GetLength(0) > 0)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Gizmos.DrawSphere(nodes[j, i].position, 0.2f);
                }
            }
        }
        
    }
}
