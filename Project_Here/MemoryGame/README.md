# Cat Memory Game

A simple memory card game built with C#, ASP.NET, HTML, CSS, and JavaScript. The game uses TheCatAPI to get random cat images and turns them into matching card pairs. The player clicks cards to reveal the cat image underneath and tries to find all matching pairs.

## Project Overview

The goal of this project is to practice building a small full-stack web application. The C# backend gets cat image data from an external API, and the JavaScript frontend uses that data to create an interactive memory game.

## Features

* Fetches random cat images from TheCatAPI
* Creates matching card pairs from the image data
* Shuffles the cards using the Fisher-Yates shuffle algorithm
* Allows players to click cards to reveal images
* Checks whether two selected cards match
* Hides cards again if they do not match
* Keeps matched cards revealed
* Shows the player’s matched pair progress
* Includes a restart button to start a new game
* Custom background and card cover design

## Tech Stack

* C#
* ASP.NET Core
* HTML
* CSS
* JavaScript
* TheCatAPI

## API Used

This project uses TheCatAPI to get random cat images:

```text
https://api.thecatapi.com/v1/images/search?limit=10
```

For this project, only 5 images are used to create 5 matching pairs:

```text
5 cat images × 2 = 10 cards total
```

## How It Works

1. The user opens the website.
2. JavaScript calls the local C# API route:

```text
/api/cats
```

3. The C# backend calls TheCatAPI and receives cat image data.
4. JavaScript takes the cat images and creates two cards for each image.
5. The cards are shuffled randomly.
6. The cards are displayed on the webpage.
7. The player clicks two cards.
8. If the two cards have the same ID, they stay revealed.
9. If they do not match, they hide again after one second.
10. The game ends when all pairs are found.

## Project Structure

```text
CatMemoryGame/
├── Program.cs
├── CatMemoryGame.csproj
└── wwwroot/
    ├── index.html
    ├── style.css
    ├── app.js
    └── assets/
        ├── background2.png
        └── card-cover.png
```

## How to Run

Clone the repository and open the project folder:

```bash
cd CatMemoryGame
```

Run the ASP.NET project:

```bash
dotnet run
```

Then open the localhost URL shown in the terminal, for example:

```text
http://localhost:5000
```

You can also test the backend API directly by opening:

```text
http://localhost:5000/api/cats
```

## Important Note About API Keys

TheCatAPI can be used without an API key for this basic project. If an API key is needed in the future, it should not be written directly into the code because this repository is public.

A safer method would be to store the API key in an environment variable.

## What I Learned

Through this project, I practiced:

* Creating an ASP.NET Core web project
* Building a backend API route in C#
* Using `HttpClient` to call an external API
* Reading JSON data
* Creating HTML elements dynamically with JavaScript
* Using JavaScript event listeners
* Managing game state with variables
* Checking matching logic between two selected cards
* Using CSS Grid to display cards
* Styling a custom game interface

## Future Improvements

* Add a move counter
* Add a timer
* Add difficulty levels
* Add more card pairs
* Add animations when cards flip
* Add a winning screen
* Add sound effects
* Store best scores
