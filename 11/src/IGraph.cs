public interface IGraph
{
    void AddEdge(int u, int v);
    bool HasEdge(int u, int v);
    void DeleteEdge(int u, int v);
    IEnumerable<int> GetNeighborsOf(int u);
    IEnumerable<int> AllNodes { get; }
    public int NodeCount { get; }
    public int EdgeCount { get; }
}