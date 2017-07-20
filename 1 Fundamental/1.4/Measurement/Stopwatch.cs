using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    public class Stopwatch
    {
        private readonly DateTime start;

        /// <summary>
        /// 新建并开始一个计时器。
        /// </summary>
        public Stopwatch()
        {
            this.start = DateTime.Now;
        }

        /// <summary>
        /// 获取自计时器创建以来所过去的时间（秒）。
        /// </summary>
        /// <returns></returns>
        public double ElapsedTime()
        {
            DateTime now = DateTime.Now;
            return (now - start).TotalMilliseconds / 1000.0;
        }
    }
}
