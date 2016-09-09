# kata-nethack
The aim of this kata is to try and support a few different teams in parallel working on building a simple dungeon exploration game.

# Minimum Viable Product Stages

## Stage 1
Render a dungeon to the screen using ASCII characters to represent various elements. 
Player can use the W,A,S,D keys to move around the dungeon.
The game stops once the player reaches the exit

The dungeon consists of a single hardcoded map with the following characteristics
1 - The map is of the size 10 x 10
2 - A single x/y coordinate of the map is represented by a tile
3 - A tile can only be of the following Type
    * The exit (only 1)
    * The starting point for player (only 1)
    * A wall
    * A passageway

Valid movements for a player can make movements of North, South, East, West


