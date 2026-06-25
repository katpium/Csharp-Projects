string SecretWord = "apple";
int hearts = 6;
bool hasWon = false;
List<string> guessedLetters = new List<string>();

Console.WriteLine();
Console.WriteLine("Welcome to Hangman!");
Console.WriteLine("The secret word has " + SecretWord.Length + " letters.");

while (hearts > 0 && !hasWon) {
    
    Console.WriteLine();
    Console.WriteLine("Hearts remaining: " + hearts);
    Console.WriteLine();

    Console.WriteLine("Please enter a letter:");
    string input = Console.ReadLine();

    if (input.Length != 1 || !char.IsLetter(input[0]))
    {
        Console.WriteLine("Please enter a single letter.");
        continue;
    }

    Console.WriteLine("You guessed:" + input);

    guessedLetters.Add(input);

    if (SecretWord.Contains(input))
    {
        Console.WriteLine("Correct!");
    }
    else
    {
        Console.WriteLine("Wrong!");
        hearts--;
    }
    Console.WriteLine("__________________________________________");
    Console.WriteLine("Current word:");

    hasWon = true;

    foreach (char letter in SecretWord)
    {
        if(guessedLetters.Contains(letter.ToString()))
        {
            Console.Write(letter + " ");
        }
        else
        {
            Console.Write("_ ");
            hasWon = false;
        }
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Guessed letters:");
    foreach (string letter in guessedLetters)
    {
        Console.WriteLine(letter);
    }
}

if (hasWon)
{
    Console.WriteLine("Congratulations! You've guessed the word: " + SecretWord);
}
else
{
    Console.WriteLine("Game Over! The secret word was: " + SecretWord);
}