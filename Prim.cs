using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_generator
{
    public class Prim
    {
        private List<Vertex> graph;
        public Prim(List<Vertex> graph)
        {
            this.graph = graph;
        }

        public void Run()
        {
            if(graph.Count() > 0)
            {
                graph.First();
            }

            while (IsDisconnected())
            {
                Edge nextMinimum = new Edge(int.MaxValue);
                Vertex nextVertex = graph.First();
                foreach (Vertex vertex in graph)
                {
                    if (vertex.IsVisited())
                    {
                        KeyValuePair<Vertex, Edge> candidate = vertex.NextMinimum();
                        if(candidate.Value.GetWeight() < nextMinimum.GetWeight())
                        {
                            nextMinimum = candidate.Value;
                            nextVertex = candidate.Key;
                            
                        }
                    }
                }

                Console.WriteLine($"Next vertex {nextVertex.GetLabel()}");
                
                nextMinimum.SetIncluded(true);
                nextVertex.SetVisited(true);
            }
        }

        private bool IsDisconnected()
        {
            foreach(Vertex vertex in graph)
            {
                if (!vertex.IsVisited())
                {
                    return true;
                }
            }
            return false;
        }
        public string OriginalGraphToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Vertex vertex in graph)
            {
                sb.Append(vertex.OriginalToString());
            }
            return sb.ToString();
        }

        public void ResetPrintHistory()
        {
            foreach (Vertex vertex in graph)
            {
                foreach (KeyValuePair<Vertex, Edge> pair in vertex.GetEdges())
                {
                    pair.Value.SetPrinted(false);
                }
            }
        }

        public string MinimumSpanningTreeToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Vertex vertex in graph)
            {
                sb.Append(vertex.IncludedToString());
            }
            return sb.ToString();
        }

    }
}
