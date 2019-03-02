# Algorithms-4th-Edition

算法（第4版）习题题解 C# 版，勘误感谢名单：[THANKS.md](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/blob/master/THANKS.md)

当前已经完成到 3.1。

可以在这个网站搜索题解：https://alg4.ikesnowy.com/

章节类库的 API 文档：https://alg4.ikesnowy.com/docs/api/index.html

## 目录

- [1.基础 Fundamental](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental)
  - [1.1 基础编程模型 Programming Model](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.1)
  - [1.2 数据抽象 Data Abstraction](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.2)
  - [1.3 背包、队列和栈 Bags, Queues, and Stacks](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.3)
  - [1.4 算法分析 Analysis of Algorithms](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.4)
  - [1.5 案例研究：union-find 算法 CaseStudy: UnionFind](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.5)

- [2.排序 Sorting](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting)
  - [2.1 初级排序算法 Elementary Sorts](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.1)
  - [2.2 归并排序 Mergesort](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.2)
  - [2.3 快速排序 Quicksort](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.3)
  - [2.4 优先队列 Priority Queues](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.4)
  - [2.5 应用 Sorting Applications](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/2%20Sorting/2.5)

- [3.查找 Searching](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching)
  - [3.1 符号表 Elementary Symbol Tables](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/3%20Searching/3.1)

## 使用方法 & 开发环境

### 使用方法：

有时题目标号文件夹下只有用例（即 Main 方法），实际编写的类位于章节对应的类库中。
有关章节类库和 API 文档的说明请见：[如何：查找 API 说明](https://alg4.ikesnowy.com/如何：查找-API-说明/)

配置运行题解代码的详细教程见：[如何：运行题解代码？](https://alg4.ikesnowy.com/如何%EF%BC%9A运行题解代码/)。

获取图文版解答可以参考 [我的博客](http://www.cnblogs.com/ikesnowy/) （博客园）或者 [题解网站](https://alg4.ikesnowy.com/) （GitHub Pages）。

### 文件说明：

#### 控制台应用程序  

Program.cs 是程序的运行代码。 
需要实现的类会位于其他源文件中，例如实现有理数类的代码就会在同项目下的 Rational.cs 文件中。  

#### Windows 窗体应用程序

题目说明位于 Program.cs 文件中，绘图和逻辑部分代码可能在窗体文件，也可能在 Program.cs 中。  

### 开发环境： 

Visual Studio 2017 + .NET Framework 4.7  

## 代码规范

主要参照 [Framework Design Guidelines](https://docs.microsoft.com/zh-cn/dotnet/standard/design-guidelines/)（本人翻译的 [版本](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/blob/master/C%23%20框架设计指南.md)） 和 [C# 编程指南](https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/index) ，以及以下几条附加内容。

1. 单行注释（"//"）和注释内容之间必须有一个空格。中英文字符之间也需要有一个空格。例如：

   ```c#
   // 这是一行 C# 注释内容。
   ```

2. 类前的修饰符参照如下顺序排列，参照 [C# 语言规范](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/classes#class-declarations)。

   ```csharp
   new
   public/protected/internal/private
   abstract
   sealed
   static
   ```

3. 方法前的修饰符参照如下顺序排列。

   ```csharp
   new
   public/protected/internal/private
   static
   virtual
   sealed
   override
   abstract
   extern
   async
   ```

4. 字段前的修饰符按照如下顺序排列。

   ```csharp
   new
   public/protected/internal/private
   static
   readonly
   volatile
   ```

5. 属性前的修饰符按如下顺序排列。

   ```csharp
   new
   public/protected/internal/private
   static
   virtual
   sealed
   override
   abstract
   extern
   ```

   例子：

   ```csharp
   public abstract class BubbleSort : Sort
   {
     public static abstract void Sort (IComparable[] a);
     private static override void Show();
   }
   ```

## 相关资料  

官方 MOOC 课程： 

Part1 https://www.coursera.org/learn/algorithms-part1

Part2 https://www.coursera.org/learn/algorithms-part2

官方资料站 (English): http://algs4.cs.princeton.edu/
