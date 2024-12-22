# Minesweeper game

## About
This application is an implementation of the classic Minesweeper game. The objective is to uncover all safe cells without triggering a bomb. Before diving into the game, users are greeted with an initial form where they should enter their name. Also they can review the rules in a dedicated form provided in the menu. To begin the game, players first select the grid size, which determines the difficulty level. Once the grid size is chosen, the game announces the total number of bombs that will be present in the current play session.

## Developed with
- C# and Windows Forms
  
## Application features
- Player name input validation - clear error messages and visual indicators, alerting users of invalid inputs
- Three difficulty levels: easy, medium, and hard
- Dynamic game grids based on difficulty level: 5x5, 10x10, and 15x15
- Timer functionality to track elapsed game time
- Ability to save game results to a text file (in csv format)
- Safe first-click mechanics ensuring no bomb is triggered on the first move
- Ability to flag or unflag a button to mark suspected bombs
- Visual feedback for opened cells and flagged bombs
- Automatic opening of safe regions - when a cell with no neighbouring bombs (0) is clicked, all ajdacent and connected safe cells are revealed automatically
