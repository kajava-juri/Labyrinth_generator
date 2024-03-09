using System;
using System.Collections.Generic;

namespace Labyrinth_generator
{
    class Program
    {
		
		static void Main(string[] args)
        {
            Prim prim = new Prim(CreateGraph());
            Console.WriteLine(prim.OriginalGraphToString());
            Console.WriteLine("----------------");
            prim.Run();
            Console.WriteLine();
            prim.ResetPrintHistory();
            Console.WriteLine(prim.MinimumSpanningTreeToString());


        }

        public static List<Vertex> CreateGraph()
        {
            List<Vertex> graph = new List<Vertex>();

            Vertex[,] vertices = new Vertex[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    vertices[i, j] = new Vertex($"Vertex_{i}_{j}");
                    graph.Add(vertices[i, j]);
                }
            }

            // Connect vertices horizontally
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Edge edge = new Edge(new Random().Next(101)); // Random weight between 0 and 100
                    vertices[i, j].AddEdge(vertices[i, j + 1], edge);
                    vertices[i, j + 1].AddEdge(vertices[i, j], edge);
                }
            }

            // Connect vertices vertically
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Edge edge = new Edge(new Random().Next(101)); // Random weight between 0 and 100
                    vertices[i, j].AddEdge(vertices[i + 1, j], edge);
                    vertices[i + 1, j].AddEdge(vertices[i, j], edge);
                }
            }

            return graph;

            //List<Vertex> graph = new List<Vertex>();
            //Vertex a = new Vertex("A");
            //Vertex b = new Vertex("B");
            //Vertex c = new Vertex("C");
            //Vertex d = new Vertex("D");
            //Vertex e = new Vertex("E");

            //graph.Add(a);
            //graph.Add(b);
            //graph.Add(c);
            //graph.Add(d);
            //graph.Add(e);

            //Edge ab = new Edge(2);
            //a.AddEdge(b, ab);
            //b.AddEdge(a, ab);
            //Edge ac = new Edge(3);
            //a.AddEdge(c, ac);
            //c.AddEdge(a, ac);
            //Edge bc = new Edge(2);
            //b.AddEdge(c, bc);
            //c.AddEdge(b, bc);
            //Edge be = new Edge(5);
            //b.AddEdge(e, be);
            //e.AddEdge(b, be);
            //Edge cd = new Edge(1);
            //c.AddEdge(d, cd);
            //d.AddEdge(c, cd);
            //Edge ce = new Edge(1);
            //c.AddEdge(e, ce);
            //e.AddEdge(c, ce);

            //return graph;
        }
    }
}
