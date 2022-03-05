using System;
using _3._1._27;

var random = new Random();
var n = 3000;
var data = new int[n];
for (var i = 0; i < n; i++)
    data[i] = i;
Shuffle(data);

Console.WriteLine("\t比较\t交换\t总和");
Console.Write("Put()\t");
var bst = new BinarySearchSt<int, int>(n);
for (var i = 0; i < n; i++)
{
    bst.Put(data[i], i);
}

Console.WriteLine(bst.Compares + "\t" + bst.Exchanges + "\t" + (bst.Compares + bst.Exchanges));
bst.Compares = 0;
bst.Exchanges = 0;

Console.Write("Get()\t");
var s = (int)(n + (n * n - n) / (4 * Math.Log(n, 2)));
var query = new int[s];
for (var i = 0; i < s; i++)
{
    query[i] = random.Next(n);
}

for (var i = 0; i < s; i++)
{
    bst.Get(query[i]);
}

Console.WriteLine(bst.Compares + "\t" + bst.Exchanges + "\t" + (bst.Compares + bst.Exchanges));

static void Shuffle(int[] data)
{
    var random = new Random();
    for (var i = 0; i < data.Length; i++)
    {
        var r = i + random.Next(data.Length - i);
        var temp = data[i];
        data[i] = data[r];
        data[r] = temp;
    }
}