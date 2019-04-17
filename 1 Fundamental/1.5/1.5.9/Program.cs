﻿namespace _1._5._9
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * 不可能。
             * 树如下所示，缩进表示子结点。
             * 
             * 1
             * ---- 0
             * ---- 3
             *     ---- 2
             *     ---- 7
             * ---- 6
             *   ---- 5
             *       ---- 9
             *       ---- 4
             *           ---- 8
             *             
             * 由于加权 quick-union 算法任意节点的最大深度为 lgN （节点总数为 N）。
             * （这个结论可以在中文版 P146，或者英文版 P228 找到）
             * 上面这个树的最大深度为 5 > lg10
             * 因此这棵树不可能是通过加权 quick-union 算法得到的。
             * 
             */
        }
    }
}
