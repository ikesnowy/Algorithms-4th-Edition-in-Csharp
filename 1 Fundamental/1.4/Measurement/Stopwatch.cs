using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    public class Stopwatch
    {
        private readonly long start;

        /// <summary>
        /// 新建并开始一个计时器。
        /// </summary>
        public Stopwatch()
        {
            this.start = DateTime.Now.Millisecond;
        }

        /// <summary>
        /// 获取自计时器创建以来所过去的时间（秒）。
        /// </summary>
        /// <returns></returns>
        public double ElapsedTime()
        {
            long now = DateTime.Now.Millisecond;
            return (now - start) / 1000.0;
        }
    }
}
