using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._46
{
    /*
     * 1.3.46
     * 
     * 栈的可生成性问题中禁止出现的排列。
     * 若三元组 (a, b, c) 中 a<b<c 且 c 最先被弹出，a 第二，b 第三
     * （c 和 a 以及 a 和 b 之间可以间隔其他整数），
     * 那么当且仅当排列中不含这样的三元组时（如上题所述的）栈才可能生成它。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //证明参考：http://ceeji.net/blog/forbidden-triple-for-stack-generability/
            //显然书中的解答已经十分明确，这里简单说明一下：
            //首先有结论：对于栈顶元素 Sn，栈中所有小于 Sn 的值都以递减形式保存（已经输出的不算）。
            //表现在输出序列中，Sn 输出之后，如果有小于 Sn 的值输出，其顺序必定是递减的。
            //例如序列 4 3 2 1 0 9 8 7 6 5
            //4 输出之后，3 2 1 0 递减输出；9 输出之后，8 7 6 5 递减输出。
            //依次验证其中的每个值都能满足结论。
            //而对于序列 4 6 8 7 5 3 2 9 0 1
            //对于 4，之后的 3 2 1 0 并不是以递减顺序输出的，因此这个序列是不合法的。
        }
    }
}
