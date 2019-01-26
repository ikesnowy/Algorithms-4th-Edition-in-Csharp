using System;
using System.Collections.Generic;

namespace SortApplication
{
    /// <summary>
    /// A* 搜索器。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AStar<T> where T : IComparable<T>
    {
        /// <summary>
        /// 相等比较器。
        /// </summary>
        private readonly IEqualityComparer<T> equalityComparer;

        /// <summary>
        /// 默认相等比较器。
        /// </summary>
        class DefaultEqualityComparer : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// 根据 FScore 进行比较的比较器。
        /// </summary>
        class FScoreComparer : IComparer<T>
        {
            Dictionary<T, int> fScore;

            public FScoreComparer(Dictionary<T, int> fScore)
            {
                this.fScore = fScore;
            }

            public int Compare(T x, T y)
            {
                if (!this.fScore.ContainsKey(x))
                    this.fScore[x] = int.MaxValue;
                if (!this.fScore.ContainsKey(y))
                    this.fScore[y] = int.MaxValue;
                return this.fScore[x].CompareTo(this.fScore[y]);
            }
        }

        /// <summary>
        /// 新建一个 Astar 寻路器，使用元素默认相等比较器。
        /// </summary>
        protected AStar() : this(new DefaultEqualityComparer()) { }

        /// <summary>
        /// 新建一个 AStar 寻路器。
        /// </summary>
        /// <param name="equalityComparer">用于确定状态之间相等的比较器。</param>
        protected AStar(IEqualityComparer<T> equalityComparer)
        {
            this.equalityComparer = equalityComparer;
        }

        /// <summary>
        /// 获得最短路径。
        /// </summary>
        /// <param name="start">起始状态。</param>
        /// <param name="goal">终止状态。</param>
        /// <returns></returns>
        public T[] GetPath(T start, T goal)
        {
            Dictionary<T, T> comeFrom = new Dictionary<T, T>(this.equalityComparer);
            Dictionary<T, int> gScore = new Dictionary<T, int>(this.equalityComparer);
            Dictionary<T, int> fScore = new Dictionary<T, int>(this.equalityComparer);

            MinPQ<T> openSet = new MinPQ<T>(new FScoreComparer(fScore), this.equalityComparer);
            HashSet<T> closeSet = new HashSet<T>(this.equalityComparer);

            openSet.Insert(start);
            gScore.Add(start, 0);
            fScore.Add(start, HeuristicDistance(start, goal));
            while (!openSet.IsEmpty())
            {
                T current = openSet.DelMin();
                if (this.equalityComparer.Equals(current, goal))
                    return ReconstructPath(comeFrom, current);

                closeSet.Add(current);

                T[] neighbors = GetNeighbors(current);
                foreach (T neighbor in neighbors)
                {
                    if (closeSet.Contains(neighbor))
                        continue;

                    int gScoreTentative = gScore[current] + ActualDistance(current, neighbor);

                    // 新状态
                    if (!openSet.Contains(neighbor))
                        openSet.Insert(neighbor);
                    else if (gScoreTentative >= gScore[neighbor])
                        continue;

                    // 记录新状态
                    comeFrom[neighbor] = current;
                    gScore[neighbor] = gScoreTentative;
                    fScore[neighbor] = gScore[neighbor] + HeuristicDistance(neighbor, goal);
                }
            }

            return null;
        }

        /// <summary>
        /// 倒回重建最佳路径。
        /// </summary>
        /// <param name="status">包含所有状态的数组。</param>
        /// <param name="from">记载了状态之间顺序的数组。</param>
        /// <param name="current">当前状态位置。</param>
        /// <returns></returns>
        private T[] ReconstructPath(Dictionary<T, T> comeFrom, T current)
        {
            Stack<T> pathReverse = new Stack<T>();
            while (comeFrom.ContainsKey(current))
            {
                pathReverse.Push(current);
                current = comeFrom[current];
            }
            T[] path = new T[pathReverse.Count];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = pathReverse.Pop();
            }
            return path;
        }

        /// <summary>
        /// 计算两个状态之间的估计距离，即 h(n)。
        /// </summary>
        /// <param name="start">初始状态。</param>
        /// <param name="goal">目标状态。</param>
        /// <returns></returns>
        protected abstract int HeuristicDistance(T start, T goal);

        /// <summary>
        /// 计算两个状态之间的实际距离，即 g(n)。
        /// </summary>
        /// <param name="start">初始状态。</param>
        /// <param name="goal">目标状态。</param>
        /// <returns></returns>
        protected abstract int ActualDistance(T start, T goal);

        /// <summary>
        /// 获得当前状态的周围状态。
        /// </summary>
        /// <param name="current">当前状态。</param>
        /// <returns></returns>
        protected abstract T[] GetNeighbors(T current);
    }
}
