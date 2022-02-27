﻿// 在高德纳的《计算机程序设计艺术》第一卷里出现了这个公式，编号为2.3.4.5(3)。
// 书中的证明简单直接：

// 考虑二叉树中的某个叶子结点 V，设根结点到它的路径长度为 k，现在将 V 删去。
// 对于二叉树的内部路径长度 I 和外部路径长度 E：
// 由于 V 被删去，E 将会减少 2(k + 1)，I 将会减少 k，但此时 V 变成了一个外部结点，E 又会加上 k。
// 因此最后 E 减少了 k + 2，I 减少了 k，重复 N 次操作之后就可以得到 E = I + 2N。

return;