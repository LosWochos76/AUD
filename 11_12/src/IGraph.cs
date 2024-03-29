public interface IGraph
{
    bool IsDirected { get; }
    bool IsUndirected { get; }
    public int NodeCount { get; }
    public int EdgeCount { get; }
    void AddEdge(int u, int v, double weight = 1);
    bool HasEdge(int u, int v);
    void DeleteEdge(int u, int v);
    IEnumerable<int> GetNeighborsOf(int u);
    IEnumerable<Edge> GetEdgesFrom(int u);
    IEnumerable<int> AllNodes { get; }
    IEnumerable<Edge> AllEdges { get; }
    double GetWeight(int u, int v);
    void Clear();
}