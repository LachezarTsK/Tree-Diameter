
/**
 * @param {number[][]} edges
 * @return {number}
 */
var treeDiameter = function (edges) {
    if (edges.length === 0) {
        return 0;
    }

    this.totalNodes = edges.length + 1;
    this.diameter = 0;
    this.graph = Array.from(new Array(this.totalNodes + 1), () => new Array());

    createGraph(edges);
    depthFirstSearch(0, new Array(this.totalNodes));

    return this.diameter;
};

/**
 * @param {number} node
 * @param {boolean[]}visited
 * @return {number}
 */
function depthFirstSearch(node, visited) {
    let largestDistance = 0;
    let secondLargestDistance = 0;

    visited[node] = true;

    for (let nextNode of this.graph[node]) {
        let currentDistance = 0;
        if (!visited[nextNode]) {
            currentDistance = 1 + depthFirstSearch(nextNode, visited);
        }

        if (currentDistance > largestDistance) {
            secondLargestDistance = largestDistance;
            largestDistance = currentDistance;
        } else if (currentDistance > secondLargestDistance) {
            secondLargestDistance = currentDistance;
        }
        this.diameter = Math.max(this.diameter, largestDistance + secondLargestDistance);
    }
    return largestDistance;
}

/**
 * @param {number[][]} edges
 * @return {void}
 */
function createGraph(edges) {
    for (let [firstNode, secondNode] of edges) {
        this.graph[firstNode].push(secondNode);
        this.graph[secondNode].push(firstNode);
    }
}
