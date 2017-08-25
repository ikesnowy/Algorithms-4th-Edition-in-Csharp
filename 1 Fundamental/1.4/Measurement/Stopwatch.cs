using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    /// <summary>
    /// 计时器类。
    /// </summary>
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
            return (now - this.start).TotalMilliseconds / 1000.0;
        }

        /// <summary>
        /// 获取自计时器创建以来所过去的时间（毫秒）。
        /// </summary>
        /// <returns></returns>
        public double ElapsedTimeMillionSeconds()
        {
            DateTime now = DateTime.Now;
            return (now - this.start).TotalMilliseconds;
        }
    }
}
