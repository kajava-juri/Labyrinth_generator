using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_generator
{
    public class Prim
    {
        private List<Vertex> graph;
        private List<Tuple<int, int>> vertexOrder = new List<Tuple<int, int>>();
        private int width;
        private int height;
        public Prim(List<Vertex> graph, int width, int height)
        {
            this.graph = graph;
            this.width = width;
            this.height = height;
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
                vertexOrder.Add(nextVertex.GetCoordinates());
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
            System.Text.StringBuilder tocsv = new System.Text.StringBuilder();
            foreach (Vertex vertex in graph)
            {
                (string,string) formattedStrings = vertex.IncludedToString();
                sb.Append(formattedStrings.Item1);
                tocsv.Append(formattedStrings.Item2);



            }
            // Write values to the file
            using (StreamWriter writer = new StreamWriter("adjaceny.csv"))
            {
                writer.WriteLine($"{width},{height}");
                writer.WriteLine(tocsv.ToString());

            }
            // Write values to the file
            using (StreamWriter writer = new StreamWriter("output.csv"))
            {
           
                foreach (Tuple<int, int> coord in vertexOrder)
                {
                    writer.WriteLine($"x={coord.Item1},y={coord.Item2}");
                }

            }
            return sb.ToString();
        }

    }
}
