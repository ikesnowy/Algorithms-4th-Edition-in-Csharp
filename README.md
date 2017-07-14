# Algorithms-4th-Edition

算法（第4版）习题题解 C# 版  

当前已经完成到 1.3  

1.4 预计在八月上旬完成，可以通过 Issues 和 Milestone 来了解进度。 

## 目录

- [1.基础 Fundamental](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental)
  - [1.1 基础编程模型](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.1)  

  - [1.2 数据抽象](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.2) 

    [1.2 类库 Geometry (Point2D.cs Interval1D.cs Interval2D.cs)](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.2/Geometry) 

    [1.2 类库 Commercial (Date.cs Transaction.cs)](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.2/Commercial)  

  - [1.3 背包、队列和栈](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.3)

    [1.3 类库 Generics(Bag.cs LinkedList.cs Node.cs Queue.cs Stack.cs)](https://github.com/ikesnowy/Algorithms-4th-Edition-in-Csharp/tree/master/1%20Fundamental/1.3/Generics)

## 使用方法 & 测试环境

### 使用方法：  

1. 下载整个解决方案（可能会非常大），打开 Algorithms 4th Edition.sln 文件，右击需要的项目--设为启动项目，运行。  
2. 下载你需要的项目文件和库文件（库文件一般位于相应章节文件夹下），添加到 Visual Studio 中运行。 
   例如，下载了 1.3.26 和 Generics 文件夹。打开 1.3.26 文件夹下的项目文件之后（后缀为 .csproj 的文件），Visual Studio 会自动生成一个解决方案。 
   之后点击左上角 “文件”——“添加”——“现有项目”，找到 Generics 文件夹下的项目文件并添加，之后就可以编译并运行 1.3.26 的程序了。  
3. 直接在 Github 上查看、复制源代码。  
4. 去 [我的博客](http://www.cnblogs.com/ikesnowy/) 上查看相关代码和解释。  

### 文件说明：

#### 控制台应用程序  

Program.cs 是程序的运行代码。 
需要实现的类会位于其他源文件中，例如实现有理数类的代码就会在同项目下的 Rational.cs 文件中。  

#### Windows 窗体应用程序

实现主要逻辑的代码都放在 Program.cs 文件中，窗体的源文件仅包含格式校验等次要功能的代码。  

### 目标平台 & 测试环境：  

Windows10 15063 + Visual Studio 2017 + .NET Framework 4.7  

#### 测试环境（部分题目要求测试运算时间）  

Surface Pro3

CPU: i7 4650U @1.70GHz

OS: Windows10 15063

## 相关资料  

官方MOOC课程： 

https://www.coursera.org/learn/algorithms-part1

官方资料站 (English):

http://algs4.cs.princeton.edu/
