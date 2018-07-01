using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._7
{
    /*
     * 2.2.7
     * 
     * 证明归并排序的比较次数是单调递增的
     * （即对于 N>0，C(N+1)>C(N)）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 这很显然，根据书本给出的命题 G 和命题 H（中文版 P173/176，英文版 P275/279），
            // 比较次数的下限 C(N) = 1/2 * NlgN
            // N 和 lgN 都是单调递增且大于零的(N>1)，因此 C(N) 也是单调递增的
        }
    }
}
