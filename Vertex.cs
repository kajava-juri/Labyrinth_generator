﻿using System.Collections.Generic;

namespace Labyrinth_generator
{
    public class Vertex
    {
        private string label = null;
        private Dictionary<Vertex, Edge> edges = new Dictionary<Vertex, Edge>();
        private bool isVisited = false;

        public Vertex(string label)
        {
            this.label = label;
        }

        public string GetLabel()
        {
            return label;
        }

        public void SetLabel(string label)
        {
            this.label = label;
        }

        public Dictionary<Vertex, Edge> GetEdges()
        {
            return edges;
        }

        public void AddEdge(Vertex vertex, Edge edge)
        {
            if (this.edges.ContainsKey(vertex))
            {
                if (edge.GetWeight() < this.edges[vertex].GetWeight())
                {
                    this.edges[vertex] = edge;
                }
            }
            else
            {
                this.edges[vertex] = edge;
            }
        }

        public bool IsVisited()
        {
            return isVisited;
        }

        public void SetVisited(bool visited)
        {
            isVisited = visited;
        }

        public KeyValuePair<Vertex, Edge> NextMinimum()
        {
            Edge nextMinimum = new Edge(int.MaxValue);
            Vertex nextVertex = this;
            foreach (KeyValuePair<Vertex, Edge> pair in edges)
            {
                if (!pair.Key.IsVisited())
                {
                    if (!pair.Value.IsIncluded())
                    {
                        if (pair.Value.GetWeight() < nextMinimum.GetWeight())
                        {
                            nextMinimum = pair.Value;
                            nextVertex = pair.Key;
                        }
                    }
                }
            }
            return new KeyValuePair<Vertex, Edge>(nextVertex, nextMinimum);
        }

        public string OriginalToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (KeyValuePair<Vertex, Edge> pair in edges)
            {
                if (!pair.Value.IsPrinted())
                {
                    sb.Append(GetLabel());
                    sb.Append(" --- ");
                    sb.Append(pair.Value.GetWeight());
                    sb.Append(" --- ");
                    sb.Append(pair.Key.GetLabel());
                    sb.Append("\n");
                    pair.Value.SetPrinted(true);
                }
            }
            return sb.ToString();
        }

        public string IncludedToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (IsVisited())
            {
                foreach (KeyValuePair<Vertex, Edge> pair in edges)
                {
                    if (pair.Value.IsIncluded())
                    {
                        if (!pair.Value.IsPrinted())
                        {
                            sb.Append(GetLabel());
                            sb.Append(" --- ");
                            sb.Append(pair.Value.GetWeight());
                            sb.Append(" --- ");
                            sb.Append(pair.Key.GetLabel());
                            sb.Append("\n");
                            pair.Value.SetPrinted(true);
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
