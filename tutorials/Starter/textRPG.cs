Console.WriteLine("Welcome to Text-based RPG!");

//Start with asking the player's name

Console.WriteLine("What is your name, traveler?");
string playerName = Console.ReadLine();
Console.WriteLine($"Nice to meet you, {playerName}!");
Console.WriteLine("You are about to embark on a grand adventure!");

//Create player's stats
int playerHealth = 100;
int playerAttack = 10;
int potion = 3;
int gold = 0;
int monsterDefeated = 0;

Console.WriteLine("Your starting stats are:");
Console.WriteLine($"Health: {playerHealth}");
Console.WriteLine($"Attack: {playerAttack}"); 
Console.WriteLine($"Potion: {potion}");
Console.WriteLine($"Gold: {gold}");

//Create a game loop that conitnues unil the player dies or wins
bool isPlaying = true;

while (isPlaying)
{
    Console.WriteLine();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Explore");
    Console.WriteLine("2. Check Stats");
    Console.WriteLine("3. Use Potion");
    Console.WriteLine("4. Shop");
    Console.WriteLine("5. Quit");

    string choice = Console.ReadLine();

    
    if (choice == "1")
    {
        Console.WriteLine("You venture into the unknown...");

        bool encounterMonster = new Random().Next(0, 2) == 0; // 50% chance to encounter a monster

        if (encounterMonster) {

            int mosterHealth = 50;
            int monsterAttack = 10;
            Random rand = new Random();

            Console.WriteLine("A wild monster appears!");

            while (mosterHealth > 0 && playerHealth > 0) {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Run");
                Console.WriteLine("3. Use Potion");

                string battleChoice = Console.ReadLine();

                if (battleChoice == "1") {   
                    int monsterDamage = rand.Next(5, monsterAttack + 1);
                    mosterHealth -= playerAttack;
                    Console.WriteLine($"You attack the monster for {playerAttack} damage!");
                    
                    if (mosterHealth > 0) {
                        playerHealth -= monsterDamage;
                        Console.WriteLine($"The monster attacks you for {monsterDamage} damage!");
                        Console.WriteLine($"Your health: {playerHealth}");
                        Console.WriteLine($"Monster's health: {mosterHealth}");
                    }
                    
                    else {
                        Console.WriteLine("You defeated the monster!");
                        monsterDefeated++;
                        gold += 10;
                        Console.WriteLine("You found 10 gold!");
                        Console.WriteLine($"Total monsters defeated: {monsterDefeated}");
                        
                        if (monsterDefeated == 3) {
                            Console.WriteLine("Congratualation! You defeated enough monsters and became a hero!");
                            isPlaying = false;
                            break;
                        }
                    }
                }
                
                else if (battleChoice == "2") {
                    Console.WriteLine("You run away from the monster!");
                    break;
                }
                
                else if (battleChoice == "3") {
                    if (potion > 0) {
                        playerHealth += 20;
                        potion--;
                        Console.WriteLine("You used a potion and restored 20 health!");
                        Console.WriteLine($"Health: {playerHealth}");
                        Console.WriteLine($"Potion: {potion}");
                    }
                    
                    else
                    {
                        Console.WriteLine("You have no potions left!");
                    }
                    }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }

                if (playerHealth <= 0)
                {
                    Console.WriteLine("You have been defeated by the monster...");
                    isPlaying = false;
                    break;
                }
            }
        }
    }
    else if (choice == "2")
    {
        Console.WriteLine($"Health: {playerHealth}");
        Console.WriteLine($"Attack: {playerAttack}");
        Console.WriteLine($"Potion: {potion}");
        Console.WriteLine($"Gold: {gold}");
    }
    else if (choice == "3")
    {
        if (potion > 0)
        {
            playerHealth += 20;
            potion--;
            Console.WriteLine("You used a potion and restored 20 health!");
            Console.WriteLine($"Health: {playerHealth}");
            Console.WriteLine($"Potion: {potion}");
        }
        else
        {
            Console.WriteLine("You have no potions left!");
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine("1. Buy Potion (10 gold)");
        Console.WriteLine("2. Upgrade Attack (20 gold)");
        Console.WriteLine("3. Exit Shop");

        string shopChoice = Console.ReadLine();

        if (shopChoice == "1")
        {
            if (gold >= 10)
            {
                potion++;
                gold -= 10;
                Console.WriteLine("You bought a potion!");
                Console.WriteLine($"Potion: {potion}");
                Console.WriteLine($"Gold: {gold}");
            }
            else
            {
                Console.WriteLine("You don't have enough gold!");
            }
        }
        else if (shopChoice == "2")
        {
            if (gold >= 20)
            {
                playerAttack += 5;
                gold -= 20;
                Console.WriteLine("You upgraded your attack! Your attack increased by 5.");
                Console.WriteLine($"Attack: {playerAttack}");
                Console.WriteLine($"Gold: {gold}");
            }
            else
            {
                Console.WriteLine("You don't have enough gold!");
            }
        }
        else if (shopChoice == "3")
        {
            Console.WriteLine("Exiting the shop...");
        }
        else
        {
            Console.WriteLine("Invalid choice, please try again.");
        }
    }
    else if (choice == "5")
    {
        Console.WriteLine("Thank you for playing! Goodbye!");
        isPlaying = false;
    }
    else
    {
        Console.WriteLine("Invalid choice, please try again.");
    }
}