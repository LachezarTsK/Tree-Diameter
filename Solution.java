
import java.util.ArrayList;
import java.util.List;

public class Solution {

    private List<Integer>[] graph;
    private int totalNodes;
    private int diameter;

    public int treeDiameter(int[][] edges) {
        if (edges.length == 0) {
            return 0;
        }

        totalNodes = edges.length + 1;
        createGraph(edges);
        depthFirstSearch(0, new boolean[totalNodes]);

        return diameter;
    }

    private int depthFirstSearch(int node, boolean[] visited) {
        int largestDistance = 0;
        int secondLargestDistance = 0;

        visited[node] = true;

        for (int nextNode : graph[node]) {
            int currentDistance = 0;

            if (!visited[nextNode]) {
                currentDistance = 1 + depthFirstSearch(nextNode, visited);
            }

            if (currentDistance > largestDistance) {
                secondLargestDistance = largestDistance;
                largestDistance = currentDistance;
            } else if (currentDistance > secondLargestDistance) {
                secondLargestDistance = currentDistance;
            }
            diameter = Math.max(diameter, largestDistance + secondLargestDistance);
        }
        return largestDistance;
    }

    private void createGraph(int[][] edges) {
        graph = new List[totalNodes + 1];
        for (int i = 0; i < graph.length; ++i) {
            graph[i] = new ArrayList<>();
        }

        for (int[] edge : edges) {
            int firstNode = edge[0];
            int secondNode = edge[1];

            graph[firstNode].add(secondNode);
            graph[secondNode].add(firstNode);
        }
    }
}
