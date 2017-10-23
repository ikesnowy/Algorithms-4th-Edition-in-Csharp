using System;

namespace _1._4._34
{
    /*
     * 1.4.34
     * 
     * 热还是冷。
     * 你的目标是猜出 1 到 N 之间的一个秘密的整数。
     * 每次猜完一个整数后，你会直到你的猜测距离该秘密整数是否相等（如果是则游戏结束）。
     * 如果不相等，你会知道你的猜测相比上一次猜测距离秘密整数是比较热（接近），还是比较冷（远离）。
     * 设计一个算法在 ~2lgN 之内找到这个秘密整数，然后设计一个算法在 ~1lgN 之内找到这个秘密整数。
     * 
     */
    class Program
    {
        /// <summary>
        /// 某种方案的测试结果，包含猜测结果和尝试次数。
        /// </summary>
        struct TestResult
        {
            public int SecretNumber;// 猜测到的数字。
            public int TryTimes;    // 尝试次数。
        }

        static void Main(string[] args)
        {
            Game game = new Game(1000);
            TestResult A = PlayGameA(game);
            game.Restart();
            TestResult B = PlayGameB(game);

            Console.WriteLine($"SecretNumber:{game.SecretNumber}");
            Console.WriteLine("TestResultA:");
            Console.WriteLine($"SecretNumber:{A.SecretNumber}, TryTimes:{A.TryTimes}");
            Console.WriteLine();
            Console.WriteLine("TestResultB:");
            Console.WriteLine($"SecretNumber:{B.SecretNumber}, TryTimes:{B.TryTimes}");
        }

        /// <summary>
        /// 方案一，用二分查找实现，需要猜测 2lgN 次。
        /// </summary>
        /// <param name="game">用于猜测的游戏对象。</param>
        /// <returns>返回测试结果，包含猜测结果和尝试次数。</returns>
        static TestResult PlayGameA(Game game)
        {
            TestResult result;
            result.TryTimes = 0;
            result.SecretNumber = 0;
            GuessResult guessResult;

            int hi = game.N;
            int lo = 1;

            // 利用二分查找猜测，2lgN
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                guessResult = game.Guess(lo);
                result.TryTimes++;
                if (guessResult == GuessResult.Equal)
                {
                    result.SecretNumber = lo;
                    return result;
                }

                guessResult = game.Guess(hi);
                result.TryTimes++;
                if (guessResult == GuessResult.Equal)
                {
                    result.SecretNumber = hi;
                    return result;
                }
                else if (guessResult == GuessResult.Hot)
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }

            return result;
        }

        /// <summary>
        /// 方案二，根据 (lastGuess + nowGuess)/2 = (lo + hi) / 2 确定每次猜测的值。
        /// </summary>
        /// <param name="game">用于猜测的游戏对象。</param>
        /// <returns>返回测试结果，包含猜测结果和尝试次数。</returns>
        static TestResult PlayGameB(Game game)
        {
            TestResult result;
            result.TryTimes = 0;
            result.SecretNumber = 0;
            GuessResult guessResult;

            int hi = game.N;
            int lo = 1;
            bool isRightSide = true;

            // 第一次猜测
            guessResult = game.Guess(1);
            result.TryTimes++;
            if (guessResult == GuessResult.Equal)
            {
                result.SecretNumber = 1;
                return result;
            }

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int nowGuess = (lo + hi) - game.LastGuess;

                guessResult = game.Guess(nowGuess);
                result.TryTimes++;
                if (guessResult == GuessResult.Equal)
                {
                    result.SecretNumber = nowGuess;
                    break;
                }
                else if (guessResult == GuessResult.Hot)
                {
                    if (isRightSide)
                    {
                        lo = mid;
                    }
                    else
                    {
                        hi = mid;
                    }
                }
                else
                {
                    if (isRightSide)
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid;
                    }
                }
                isRightSide = !isRightSide;
                if (hi - lo <= 1)
                {
                    break;
                }
            }
            if (game.Guess(lo) == GuessResult.Equal)
            {
                result.TryTimes++;
                result.SecretNumber = lo;
            }
            else if (game.Guess(hi) == GuessResult.Equal)
            {
                result.TryTimes++;
                result.SecretNumber = hi;
            }

            return result;
        }
    }
}
