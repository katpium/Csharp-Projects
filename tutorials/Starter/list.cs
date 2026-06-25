List<string> names = ["<name>", "Alice", "Bob", "Charlie"];
foreach (var name in names) { //For each items inside names, TEMPORARILY call it NAME
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

void AddNames(){
    names.Add("Diana");
    names.Add("Eve");
    names.Add("Frank");
    Console.WriteLine($"The list has {names.Count} names.");
    Console.WriteLine($"My name is {names[3]}");

    foreach (var name in names) {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
}

void FindName(){
    var index = names.IndexOf("Bob");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    } else {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }

    index = names.IndexOf("Not Found");
    if (index == -1)
    {
        Console.WriteLine($"When an item is not found, IndexOf returns {index}");
    } else {
        Console.WriteLine($"The name {names[index]} is at index {index}");
    }
}

FindName();
void SortNames(){
    names.Sort();
    foreach (var name in names) {
        Console.WriteLine($"Hello {name.ToUpper()}!");
    }
}

void fibonacci(){
    List<int> fibonacciNumbers = [3, 6];
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

    fibonacciNumbers.Add(previous + previous2);

    foreach (var item in fibonacciNumbers) {
        Console.WriteLine(item);
    }
}

void fibonacciLoop(){
    List<int> fibonacciNumbers = [1, 1];
    while (fibonacciNumbers.Count <20) {
        var previous3 = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous4 = fibonacciNumbers[fibonacciNumbers.Count - 2];
        fibonacciNumbers.Add(previous3 + previous4);
    }
    foreach (var item in fibonacciNumbers) {
        Console.WriteLine(item);
    }
}