using System;
using System.Collections.Generic;

namespace Labyrinth_generator
{
    class Program
    {
		
		static void Main(string[] args)
        {
            int width = 6;
            int height = 6;
            Prim prim = new Prim(CreateGraph(width, height), width, height);
            Console.WriteLine(prim.OriginalGraphToString());
            Console.WriteLine("----------------");
            prim.Run();
            Console.WriteLine();
            prim.ResetPrintHistory();
            Console.WriteLine(prim.MinimumSpanningTreeToString());


        }

        public static List<Vertex> CreateGraph(int width, int height)
        {
            List<Vertex> graph = new List<Vertex>();

            Vertex[,] vertices = new Vertex[height, width]; // Swapped height and width to match array indexing
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    vertices[i, j] = new Vertex($"Vertex_{i}_{j}");
                    vertices[i, j].SetCoordinates(i, j);
                    graph.Add(vertices[i, j]);
                }
            }

            // Connect vertices horizontally
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width - 1; j++) // Adjusted loop limit
                {
                    Edge edge = new Edge(new Random().Next(101)); // Random weight between 0 and 100
                    vertices[i, j].AddEdge(vertices[i, j + 1], edge);
                    vertices[i, j + 1].AddEdge(vertices[i, j], edge);
                }
            }

            // Connect vertices vertically
            for (int i = 0; i < height - 1; i++) // Adjusted loop limit
            {
                for (int j = 0; j < width; j++)
                {
                    Edge edge = new Edge(new Random().Next(101)); // Random weight between 0 and 100
                    vertices[i, j].AddEdge(vertices[i + 1, j], edge);
                    vertices[i + 1, j].AddEdge(vertices[i, j], edge);
                }
            }

            return graph;

            //List<Vertex> graph = new List<Vertex>();
            //Vertex v1 = new Vertex("Vertex_0_0");
            //v1.SetCoordinates(0, 0);
            //Vertex v2 = new Vertex("Vertex_0_1");
            //v2.SetCoordinates(0, 1);
            //Vertex v3 = new Vertex("Vertex_0_2");
            //v3.SetCoordinates(0, 2);
            //Vertex v4 = new Vertex("Vertex_0_3");
            //v4.SetCoordinates(0, 3);
            //Vertex v5 = new Vertex("Vertex_1_0");
            //v5.SetCoordinates(1, 0);
            //Vertex v6 = new Vertex("Vertex_1_1");
            //v6.SetCoordinates(1, 1);
            //Vertex v7 = new Vertex("Vertex_1_2");
            //v7.SetCoordinates(1, 2);
            //Vertex v8 = new Vertex("Vertex_1_3");
            //v8.SetCoordinates(1, 3);
            //Vertex v9 = new Vertex("Vertex_2_0");
            //v9.SetCoordinates(2, 0);
            //Vertex v10 = new Vertex("Vertex_2_1");
            //v10.SetCoordinates(2, 1);
            //Vertex v11 = new Vertex("Vertex_2_2");
            //v11.SetCoordinates(2, 2);
            //Vertex v12 = new Vertex("Vertex_2_3");
            //v12.SetCoordinates(2, 3);
            //Vertex v13 = new Vertex("Vertex_3_0");
            //v13.SetCoordinates(3, 0);
            //Vertex v14 = new Vertex("Vertex_3_1");
            //v14.SetCoordinates(3, 1);
            //Vertex v15 = new Vertex("Vertex_3_2");
            //v15.SetCoordinates(3, 2);
            //Vertex v16 = new Vertex("Vertex_3_3");
            //v16.SetCoordinates(3, 3);


            //graph.Add(v1);
            //graph.Add(v2);
            //graph.Add(v3);
            //graph.Add(v4);
            //graph.Add(v5);
            //graph.Add(v6);
            //graph.Add(v7);
            //graph.Add(v8);
            //graph.Add(v9);
            //graph.Add(v10);
            //graph.Add(v11);
            //graph.Add(v12);
            //graph.Add(v13);
            //graph.Add(v14);
            //graph.Add(v15);
            //graph.Add(v16);


            //Edge e1 = new Edge(55);
            //v1.AddEdge(v2, e1);
            //v2.AddEdge(v1, e1);

            //Edge e2 = new Edge(10);
            //v2.AddEdge(v3, e2);
            //v3.AddEdge(v2, e2);

            //Edge e3 = new Edge(95);
            //v3.AddEdge(v4, e3);
            //v4.AddEdge(v3, e3);

            //Edge e4 = new Edge(58);
            //v1.AddEdge(v5, e4);
            //v5.AddEdge(v1, e4);

            //Edge e5 = new Edge(69);
            //v6.AddEdge(v2, e5);
            //v2.AddEdge(v6, e5);

            //Edge e6 = new Edge(61);
            //v3.AddEdge(v7, e6);
            //v7.AddEdge(v3, e6);

            //Edge e7 = new Edge(46);
            //v4.AddEdge(v8, e7);
            //v8.AddEdge(v4, e7);

            //Edge e8 = new Edge(62);
            //v5.AddEdge(v6, e8);
            //v6.AddEdge(v5, e8);

            //Edge e9 = new Edge(98);
            //v6.AddEdge(v7, e9);
            //v7.AddEdge(v6, e9);

            //Edge e10 = new Edge(10);
            //v7.AddEdge(v8, e10);
            //v8.AddEdge(v7, e10);

            //Edge e11 = new Edge(58);
            //v5.AddEdge(v9, e11);
            //v9.AddEdge(v5, e11);

            //Edge e12 = new Edge(58);
            //v6.AddEdge(v10, e12);
            //v10.AddEdge(v6, e12);

            //Edge e13 = new Edge(41);
            //v7.AddEdge(v11, e13);
            //v11.AddEdge(v7, e13);

            //Edge e14 = new Edge(65);
            //v8.AddEdge(v12, e14);
            //v12.AddEdge(v8, e14);

            //Edge e15 = new Edge(25);
            //v9.AddEdge(v10, e15);
            //v10.AddEdge(v9, e15);

            //Edge e16 = new Edge(21);
            //v10.AddEdge(v11, e16);
            //v11.AddEdge(v10, e16);

            //Edge e17 = new Edge(43);
            //v11.AddEdge(v12, e17);
            //v12.AddEdge(v11, e17);

            //Edge e18 = new Edge(33);
            //v9.AddEdge(v13, e18);
            //v13.AddEdge(v9, e18);

            //Edge e19 = new Edge(65);
            //v10.AddEdge(v14, e19);
            //v14.AddEdge(v10, e19);

            //Edge e20 = new Edge(16);
            //v11.AddEdge(v15, e20);
            //v15.AddEdge(v11, e20);

            //Edge e21 = new Edge(55);
            //v12.AddEdge(v16, e21);
            //v16.AddEdge(v12, e21);

            //Edge e22 = new Edge(58);
            //v13.AddEdge(v14, e22);
            //v14.AddEdge(v13, e22);

            //Edge e23 = new Edge(31);
            //v14.AddEdge(v15, e23);
            //v15.AddEdge(v14, e23);

            //Edge e24 = new Edge(55);
            //v15.AddEdge(v16, e24);
            //v16.AddEdge(v15, e24);


            //return graph;
        }
    }
}
