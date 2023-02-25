using BalancedSearchTree;

var keys = Enumerable.Range(0, 16).Select(x => (char)('A' + x)).ToArray();
Shuffle(keys);

var bst = new Bst<char, int>();
var redBlackTree = new RedBlackBst<char, int>();

foreach (var key in keys)
{
    bst.Put(key, 1);
    redBlackTree.Put(key, 1);
}

Console.WriteLine(string.Join(',', keys));
Console.WriteLine(bst);
Console.WriteLine(redBlackTree);

static void Shuffle<T>(T[] keys)
{
    var random = new Random();
    var length = keys.Length;
    for (var i = 0; i < length; i++)
    {
        var r = i + random.Next(length - i);
        var t = keys[r];
        keys[r] = keys[i];
        keys[i] = t;
    }
}