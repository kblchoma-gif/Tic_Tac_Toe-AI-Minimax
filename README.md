# Tic-Tac-Toe- AI Minimax - README

## 🎮 Overview
This is a simple AI-powered Tic-Tac-Toe game built using **C# Windows Forms**. The player competes against an AI opponent that uses the **Minimax algorithm** to make optimal decisions.

## 🧠 AI Concepts Used
### 1. **Minimax Algorithm**
- A **recursive decision-making algorithm** used in two-player games like Tic-Tac-Toe.
- It simulates all possible moves of both players to choose the move that maximizes the AI's chances of winning while minimizing the player's chances.
- The algorithm assumes:
  - **AI plays optimally (maximizing player)**
  - **Opponent (human) also plays optimally (minimizing player)**

### 2. **Game Tree Exploration**
- The algorithm explores every possible outcome (game tree) from the current state.
- Leaf nodes represent terminal game states (win, lose, draw).
- The tree is traversed using **depth-first search**.

### 3. **Evaluation Function**
- Scores each board state:
  - AI win: `+1`
  - Player win: `-1`
  - Draw: `0`

## 🤖 Decision-Making Process
1. **On each AI turn**, the Minimax function is called.
2. The AI:
   - Simulates placing its symbol on every empty cell.
   - Calls Minimax recursively to evaluate how the player would respond.
   - Collects scores for each simulated move.
3. **Best move is selected** based on the highest Minimax score.
4. The chosen move is executed on the board.

## 💡 Features
- Clickable 3x3 grid
- Player symbol: `X`
- AI symbol: `O`
- Automatic game reset after win/loss/draw

## 🛠️ How to Run
1. Open in Visual Studio
2. Create a new **Windows Forms App (.NET Framework)** project
3. Add the `Program.cs` and `MainForm.cs` files
4. Press **F5** to run

## 📂 File Structure
```
- Program.cs          // Application entry point
- MainForm.cs         // UI logic and game mechanics
```

## 📌 Notes
- The AI is unbeatable due to its exhaustive search of the game tree.
- Designed for educational purposes to demonstrate core AI logic in C#.

---
© 2025 Tic-Tac-Toe- AI Minimax Project
