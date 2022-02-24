using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1 },
            new List<int>() { 5 },
            new List<int>() { 4 }
        };

        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고,
        // 2) now와 연결된 정점들을 하나씩 확인해서 아직 미방문한 상태라면 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now 방문

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0) // 연결되어 있지 않은 노드 스킵
                    continue;
                if (visited[next]) // 이미 방문한 노드 스킵
                    continue;
                DFS(next);
            }
        }

        public void DFSList(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // now 방문

            foreach(int next in adj2[now])
            {
                if (visited[next]) // 이미 방문한 노드 스킵
                    continue;
                DFSList(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for(int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS(now);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.DFS(0);
            Console.WriteLine();
            graph.SearchAll();
        }
    }
}