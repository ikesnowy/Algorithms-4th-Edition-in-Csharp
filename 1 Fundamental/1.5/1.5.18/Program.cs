using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._18
{
    /*
     * 1.5.18
     * 
     * 随机网格生成器。编写一个程序 RandomGrid，从命令行接受一个 int 值 N，
     * 生成一个 N×N 的网格中的所有连接。
     * 它们的排列随机且方向随机（即 (p q) 和 (q p) 出现的可能性是相等的），
     * 将这个结果打印到标准输出中。
     * 可以使用 RandomBag 将所有连接随机排列（请见练习 1.3.34），
     * 并使用如右下所示的 Connection 嵌套类来将 p 和 q 封装到一个对象中。
     * 将程序打包成两个静态方法：generate()，接受参数 N 并返回一个连接的数组；
     * main()，从命令行接受参数 N，调用 generate()，便利返回的数组并打印出所有连接。
     * 
     * private class Connection
     * {
     *     int p;
     *     int q;
     * 
     *     public Connection(int p, int q)
     *     {
     *         this.p = p;
     *         this.q = q;
     *     }
     * }
     * 
     */
    class Program
    {
        /// <summary>
        /// 表示一条连接。
        /// </summary>
        private class Connection
        {
            int p;  // 起点
            int q;  // 终点

            /// <summary>
            /// 新建一条连接。
            /// </summary>
            /// <param name="p">连接起点。</param>
            /// <param name="q">连接终点。</param>
            public Connection(int p, int q)
            {
                this.p = p;
                this.q = q;
            }

            /// <summary>
            /// 获得起点 p。
            /// </summary>
            /// <returns>起点 p。</returns>
            public int GetP()
            {
                return this.p;
            }

            /// <summary>
            /// 获得终点 q。
            /// </summary>
            /// <returns>终点 q。</returns>
            public int GetQ()
            {
                return this.q;
            }

            /// <summary>
            /// 获得散列（哈希）值。
            /// </summary>
            /// <returns>散列（哈希）值。</returns>
            public override int GetHashCode()
            {
                return 31 * this.p + this.q;
            }
        }

        static void Main(string[] args)
        {
            var result = Generate(5);
            foreach (var i in result)
            {
                Console.WriteLine($"({i.GetP()}, {i.GetQ()})");
            }
        }

        /// <summary>
        /// 随机生成 n × n 网格中的所有连接。
        /// </summary>
        /// <param name="n">网格边长。</param>
        /// <returns>随机排序的连接。</returns>
        static RandomBag<Connection> Generate(int n)
        {
            var result = new RandomBag<Connection>();
            var random = new Random();
            
            // 建立横向连接
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, (i * n) + j + 1));
                    }
                    else
                    {
                        result.Add(new Connection((i * n) + j + 1, i * n + j));
                    }
                }
            }


            // 建立纵向连接
            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i < n - 1; ++i)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, ((i + 1) * n) + j));
                    }
                    else
                    {
                        result.Add(new Connection(((i + 1) * n) + j, i * n + j));
                    }
                }
            }



            return result;
        }
    }
}
