
using System;
using System.Collections.Generic;

public class Solution
{
    private IList<int>[]? graph;
    private int totalNodes;
    private int diameter;

    public int TreeDiameter(int[][] edges)
    {
        if (edges.Length == 0)
        {
            return 0;
        }

        totalNodes = edges.Length + 1;
        createGraph(edges);
        depthFirstSearch(0, new bool[totalNodes]);

        return diameter;
    }

    private int depthFirstSearch(int node, bool[] visited)
    {
        int largestDistance = 0;
        int secondLargestDistance = 0;

        visited[node] = true;

        foreach (int nextNode in graph[node])
        {
            int currentDistance = 0;

            if (!visited[nextNode])
            {
                currentDistance = 1 + depthFirstSearch(nextNode, visited);
            }

            if (currentDistance > largestDistance)
            {
                secondLargestDistance = largestDistance;
                largestDistance = currentDistance;
            }
            else if (currentDistance > secondLargestDistance)
            {
                secondLargestDistance = currentDistance;
            }
            diameter = Math.Max(diameter, largestDistance + secondLargestDistance);
        }
        return largestDistance;
    }

    private void createGraph(int[][] edges)
    {
        graph = new List<int>[totalNodes + 1];
        for (int i = 0; i < graph.Length; ++i)
        {
            graph[i] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            int firstNode = edge[0];
            int secondNode = edge[1];

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
        }
    }
}
