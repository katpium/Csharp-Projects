//Get HTML elements to JAVASCRIPT
const gameBoard = document.getElementById("game-board");
const statusText = document.getElementById("status");
const restartButton = document.getElementById("restart-button");

//Create a list for cards
let cards = [];
//Mindset
//User click 1 card -> put in first card
//User click secodn card -> put int second card
//If the same yay, no nay
let firstCard = null;
let secondCard = null;
let lockBoard = false;
let matchedPairs = 0;

//This function start or restart the game
async function startGame () {
    gameBoard.innerHTML = "";
    statusText.textContent = "Loading cat images...";

    let firstCard = null;
    let secondCard = null;
    let lockBoard = false;
    let matchedPairs = 0;

    // Call the API for cats images
    const response = await fetch("/api/cats");
    const catImage = await response.json(); //converts to JavaScript obj

    cards = createCardPairs(catImages); //take 10 cards and turn into 20 cards
    shuffleCards(cards); //shuffle it
    renderCards(cards); //create the HTML card elements
}

function createCardPairs(catImages) {
    const cardPairs = [];

    catImages.forEach((cat, index) => {
        
        //Create 2 cards
        const cardOne = {
            id: index,
            imageUrl: cat.url,
            isMatched: false
        };

        const cardTwo = {
            id: index,
            imageUrl: cat.url,
            isMatched: false
        };

        //Push the card into the array
        cardPairs.push(cardOne);
        cardPairs.push(cardTwo);
    });

    return cardPairs;
}

//Start from the last card. Pick a random card from the remaining -> SWAP IT. REPEAT
function shuffleCards(cardList) {
    //Use Fisher-Yates shuffle!!
    for(let i = cardList.length - 1; i > 0; i--){
        const randomIndex = Math.floor(Math.random()* (i + 1));

        const temp = cardList[i];
        cardList[i] = cardList[randomIndex];
        cardList[randomIndex] = temp;
    }
}

//Create visible cards on the website
function renderCards(cardList){
    cardList.forEach((card) => {

        //Initialize element into html
        const cardElement = document.createElement("div");
        cardElement.classList.add("card");
        const imageElement = document.createElement("img");
        imageElement.src = card.imageUrl;
         
        //place in GameBoard
        cardElement.appendChild(imageElement);
        gameBoard.appendChild(cardElement);

        cardElement.addEventListener("click", () => {
            handleCardClick(card, cardElement);
        });
    });
}