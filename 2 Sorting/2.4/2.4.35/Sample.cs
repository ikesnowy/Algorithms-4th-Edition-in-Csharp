using System;

namespace _2._4._35
{
    /// <summary>
    /// 离散分布的取样。
    /// </summary>
    class Sample
    {
        public double[] P;
        public double[] SumP;

        private double T = 0;
        private Random random = new Random();

        /// <summary>
        /// 构造一个离散取样类。
        /// </summary>
        /// <param name="data">取样数据。</param>
        public Sample(double[] data)
        {
            // 复制权重
            this.P = new double[data.Length + 1];
            for (var i = 1; i <= data.Length; i++)
            {
                this.P[i] = data[i - 1];
                this.T += data[i - 1];
            }

            // 记录子树权重之和
            this.SumP = new double[data.Length + 1];
            for (var i = data.Length; i / 2 > 0; i--)
            {
                this.SumP[i / 2] += this.P[i];
            }
        }

        /// <summary>
        /// 根据构造时给定的取样概率返回索引。
        /// </summary>
        /// <returns></returns>
        public int Random()
        {
            var parcentage = this.random.NextDouble() * this.T;
            var index = 1;
            while (index * 2 <= this.P.Length)
            {
                // 找到结点
                if (parcentage <= this.P[index])
                    break;
                
                // 减去当前结点，向子结点搜寻
                parcentage -= this.P[index];
                index *= 2;

                // 在左子树范围内
                if (parcentage <= this.SumP[index] + this.P[index])
                    continue;

                // 在右子树范围内，减去左子树
                parcentage -= this.SumP[index] + this.P[index];
                index++;
            }

            return index - 1;
        }

        /// <summary>
        /// 修改索引 <paramref name="i"/> 的权重为 <paramref name="v"/>。
        /// </summary>
        /// <param name="i">需要修改的索引。</param>
        /// <param name="v">新的权重。</param>
        public void Change(int i, double v)
        {
            i++;
            this.P[i] = v;
            // 重新计算总和
            while (i > 0)
            {
                i /= 2;
                this.SumP[i] = this.P[i * 2] + this.SumP[i * 2];
                if (i * 2 + 1 < this.P.Length)
                    this.SumP[i] += this.P[i * 2 + 1] + this.SumP[i * 2 + 1];
            }
        }
    }
}
