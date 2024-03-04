
#include <span>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {

    vector<vector<int>> graph;
    int totalNodes = 0;
    int diameter = 0;

public:
    int treeDiameter(const vector<vector<int>>& edges) {
        if (edges.empty()) {
            return 0;
        }
        totalNodes = edges.size() + 1;
        createGraph(edges);

        vector<bool> visited(totalNodes);
        depthFirstSearch(0, visited);
        return diameter;
    }

private:
    int depthFirstSearch(int node, vector<bool>& visited) {
        int largestDistance = 0;
        int secondLargestDistance = 0;

        visited[node] = true;

        for (const auto& nextNode : graph[node]) {
            int currentDistance = 0;

            if (!visited[nextNode]) {
                currentDistance = 1 + depthFirstSearch(nextNode, visited);
            }

            if (currentDistance > largestDistance) {
                secondLargestDistance = largestDistance;
                largestDistance = currentDistance;
            }
            else if (currentDistance > secondLargestDistance) {
                secondLargestDistance = currentDistance;
            }
            diameter = max(diameter, largestDistance + secondLargestDistance);
        }
        return largestDistance;
    }

    void createGraph(span<const vector<int>> edges) {
        graph.resize(totalNodes + 1);

        for (const auto& edge : edges) {
            int firstNode = edge[0];
            int secondNode = edge[1];

            graph[firstNode].push_back(secondNode);
            graph[secondNode].push_back(firstNode);
        }
    }
};
