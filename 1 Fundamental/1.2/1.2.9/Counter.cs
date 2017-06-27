namespace _1._2._9
{
    /// <summary>
    /// 计数器类
    /// </summary>
    class Counter
    {
        private readonly string name;
        private int count;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">计数器的名称。</param>
        public Counter(string id)
        {
            this.name = id;
        }

        /// <summary>
        /// 计数器加一。
        /// </summary>
        public void Increment()
        {
            count++;
        }

        /// <summary>
        /// 获取当前计数值。
        /// </summary>
        /// <returns></returns>
        public int Tally()
        {
            return count;
        }

        /// <summary>
        /// 输出形如 “1 counter” 的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return count + " " + name;
        }
    }
}
