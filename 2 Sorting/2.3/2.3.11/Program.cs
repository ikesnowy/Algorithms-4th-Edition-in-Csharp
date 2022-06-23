﻿// 只有若干种元素值意味着大量的连续重复。
//（由于存在打乱这一步骤，不存在连续重复的可能性是很低的）
// 接下来我们考虑这样的连续重复在修改后的快排下的性能。
// 1 1 1 1 1 1 1
// 对于这样的数组，枢轴选为 1，j 将会在 j = lo 处终止。
// 因此最后的结果将是每次只有数组的第一个元素被排序
// 已知每次切分都是 O(k - 1) 的（i 和 j 都将走完整个子数组）
// 因此这样的快速排序所需时间 = 2*(N-1 + N-2 + ... + 1) = (N-1)N
// 因此对于值相同的子数组，这样的快排运行时间是平方级别的
// 那么当数组中这样的连续重复内容越多，运行时间就越接近平方级别。

return;