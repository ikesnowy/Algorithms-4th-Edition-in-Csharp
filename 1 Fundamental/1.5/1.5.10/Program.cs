using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5._10
{
    /*
     * 1.5.10
     * 
     * 在加权 quick-union 算法中，
     * 假设我们将 id[find(p)] 的值设为 q 而非 id[find[q]]，所得的算法是正确的吗？
     * 答：是，但这会增加树的高度，因此无法保证同样的性能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 答案已经给出，这里简单解释。
            // 输入是 p、q。
            // 现在执行 union，但只是把 p 挂到 q 上而不是挂到 q 的根节点上。
            // 结果显然是整棵树的高度增加了，find 操作的效率会降低。
        }
    }
}
