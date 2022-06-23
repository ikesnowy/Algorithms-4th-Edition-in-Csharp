﻿// 修改后的算法对已经有序的情况做了优化
// 数组对半切分并排序后，
// 如果 a[mid] < a[mid+1]
// （左半部分的最后一个元素小于右半部分的第一个元素）
// 那么我们可以直接合并数组，不需要再做多余的操作
// 现在的输入是一个已经排序的数组
// 算法唯一的比较发生在判断 a[mid] < a[mid+1] 这个条件时
// 假定数组有 N 个元素
// 比较次数满足 T(N) = 2 * T(N/2) + 1, T(1) = 0
// 转化为非递归形式即为：T(N) = cN/2 + N - 1
// 其中 c 为任意正整数

return;