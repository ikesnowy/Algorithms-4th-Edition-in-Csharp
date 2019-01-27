using System;
using System.Collections.Generic;

namespace _2._5._32
{
    /*
     * 2.5.32
     * 
     * 8 字谜题。
     * 8 字谜题是 S.Loyd 于 19 世纪 70 年代发明的一个游戏。
     * 游戏需要一个三乘三的九宫格，其中八格填上了 1 到 8 这 8 个数字，一格空着。
     * 你的目标就是将所有的格子排序。
     * 可以将一个格子向上下或左右（但不能是对角线方向）移动到空白的格子中。
     * 编写一个程序用 A* 算法解决这个问题。
     * 先用到达九宫格的当前位置所需的步数加上错位的格子数量作为优先级函数
     * （注意，步数至少大于等于错位的格子数）。
     * 尝试用其他函数代替错位的格子数量，
     * 比如每个格子距离它的正确位置的曼哈顿距离，
     * 或是这些距离的平方之和。
     * 
     */
    class Program
    {
        class TilesInWrongPlace : AStarSolverFor8Puzzles
        {
            public TilesInWrongPlace(IEqualityComparer<SearchNode> e) : base(e) { }

            /// <summary>
            /// 计算错误的格子数。
            /// </summary>
            /// <param name="start">初始状态。</param>
            /// <param name="goal">目标状态。</param>
            /// <returns></returns>
            protected override int HeuristicDistance(SearchNode start, SearchNode goal)
            {
                int missTile = 0;
                for (int i = 0; i < start.Status.Length; i++)
                {
                    if (start.Status[i] != goal.Status[i])
                        missTile++;
                }
                return missTile;
            }
        }

        class ManhattanDistance : AStarSolverFor8Puzzles
        {
            public ManhattanDistance(IEqualityComparer<SearchNode> e) : base(e) { }

            /// <summary>
            /// 计算曼哈顿距离之和。
            /// </summary>
            /// <param name="start">初始状态。</param>
            /// <param name="goal">目标状态。</param>
            /// <returns></returns>
            protected override int HeuristicDistance(SearchNode start, SearchNode goal)
            {
                int manhattanSum = 0;
                for (int i = 0; i < start.Status.Length; i++)
                {
                    int goalIndex = 0;
                    for (int j = 0; j < goal.Status.Length; j++)
                        if (goal.Status[j] == start.Status[i])
                            goalIndex = j;

                    int dx = Math.Abs(i % 3 - goalIndex % 3);
                    int dy = Math.Abs(i / 3 - goalIndex / 3);
                    manhattanSum += dx + dy;
                }
                return manhattanSum;
            }
        }

        class SquareOfManhattanDistance : AStarSolverFor8Puzzles
        {
            public SquareOfManhattanDistance(IEqualityComparer<SearchNode> e) : base(e) { }

            /// <summary>
            /// 计算曼哈顿距离的平方。
            /// </summary>
            /// <param name="start">起始状态。</param>
            /// <param name="goal">目标状态。</param>
            /// <returns></returns>
            protected override int HeuristicDistance(SearchNode start, SearchNode goal)
            {
                int manhattanSquareSum = 0;
                for (int i = 0; i < start.Status.Length; i++)
                {
                    int goalIndex = 0;
                    for (int j = 0; j < goal.Status.Length; j++)
                        if (goal.Status[j] == start.Status[i])
                            goalIndex = j;

                    int dx = Math.Abs(i % 3 - goalIndex % 3);
                    int dy = Math.Abs(i / 3 - goalIndex / 3);
                    manhattanSquareSum += (dx + dy) * (dx + dy);
                }
                return manhattanSquareSum;
            }
        }

        /// <summary>
        /// 用于检查状态相同的比较器。
        /// </summary>
        class BoardEqualityComparer : IEqualityComparer<SearchNode>
        {
            public bool Equals(SearchNode x, SearchNode y)
            {
                for (int i = 0; i < x.Status.Length; i++)
                    if (x.Status[i] != y.Status[i])
                        return false;
                return true;
            }

            public int GetHashCode(SearchNode obj)
            {
                if (obj.Status.Length == 0)
                    return 0;

                int hash = 1;
                foreach (int i in obj.Status)
                {
                    hash = 31 * hash + i;
                }

                return hash;
            }
        }

        /// <summary>
        /// 打印矩阵。
        /// </summary>
        /// <param name="current">当前状态。</param>
        static void PrintMatrix(int[] current)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(current[i * 3 + j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            TilesInWrongPlace tiles = new TilesInWrongPlace(new BoardEqualityComparer());
            ManhattanDistance manhattan = new ManhattanDistance(new BoardEqualityComparer());
            SquareOfManhattanDistance manhattanSquare = new SquareOfManhattanDistance(new BoardEqualityComparer());

            SearchNode start = new SearchNode()
            {
                Status = new int[9] { 0, 1, 3, 4, 2, 5, 7, 8, 6 },
                Steps = 0
            };

            SearchNode goal = new SearchNode()
            {
                Status = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 0 },
                Steps = 0
            };

            Console.WriteLine("Missing Tiles");
            SearchNode[] path = tiles.GetPath(start, goal);
            foreach (SearchNode s in path)
                PrintMatrix(s.Status);

            Console.WriteLine("Manhattan");
            path = manhattan.GetPath(start, goal);
            foreach (SearchNode s in path)
                PrintMatrix(s.Status);

            Console.WriteLine("Square Manhattan");
            path = manhattanSquare.GetPath(start, goal);
            foreach (SearchNode s in path)
                PrintMatrix(s.Status);
        }
    }
}
