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

    firstCard = null;
    secondCard = null;
    lockBoard = false;
    matchedPairs = 0;

    // Call the API for cats images
    const response = await fetch("/api/cats");
    const catImage = await response.json(); //converts to JavaScript obj

    cards = createCardPairs(catImage); //take 10 cards and turn into 20 cards
    shuffleCards(cards); //shuffle it
    renderCards(cards); //create the HTML card elements
    
    statusText.textContent = "Find all matching cat pairs!";
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

function handleCardClick(card, cardElement) { // this function receives the card and the card HTML
    //First, check if the card is locked
    if (lockBoard) {
        return;
    }

    //To prevent clicking the card MORE than TWICE
    //If 2 card is face up -> STOP
    if (cardElement.classList.contains("revealed")) {
        return;
    }

    //If the card is already matched STOP
    if (cardElement.classList.contains("matched")) {
        return;
    }

    //Add the current card as revealed due to clicked.
    cardElement.classList.add("revealed");

    //When the user click a first card => PUT IN FIRST CARD
    if ( firstCard == null ) {
        firstCard = {
            cardData : card,
            element : cardElement,
        };
        return;
    } 
    //If the firstCard is already filled assign the current card to the SECOND CARD
    secondCard = {
        cardData : card,
        element : cardElement,
    };

    //After 2 card is assign CHECK FOR MATCH
    checkForMatch();
}

function checkForMatch(){
    if(firstCard.cardData.id === secondCard.cardData.id){
        firstCard.element.classList.add("matched");
        secondCard.element.classList.add("matched");

        //After knowing the 2 card is matched and assigned as MATCHED 
        //Put it as NULL so the slot can be contain for other cards
        firstCard = null;
        secondCard = null;

        matchedPairs++;
    } else {
        lockBoard = true; //Cannot click more card!!

        statusText.textContent = "Not a match!";
        
        setTimeout(() => {
            firstCard.element.classList.remove("revealed");
            secondCard.element.classList.remove("revealed");

            firstCard = null;
            secondCard = null;
            lockBoard = false;

            statusText.textContent = `Matched pairs: ${matchedPairs} / 10`;

            if (matchedPairs === 10) {
            statusText.textContent = "You found all cat pairs!";
}
        }, 1000 ); //set after 1 second REMOVE the revealed context
    }
}

restartButton.addEventListener("click", startGame);

startGame();