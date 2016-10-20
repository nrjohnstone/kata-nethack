# Stages and Maps

Stage is representitive of a dungeon in the game. The map is a representation of the layout. This distinction was made to easily split out the way map layout is represented. This can be refined greatly but for now it is simply within the stage as a string. Later improvements can be made to load from file.

A Map can be queried by x and y coordinate system with x running West to East and y running North to South with base index starting at 1 (not zero).

Wall: =  
Player: !  
Exit: *

## Usage

```csharp
var stage = new Stage1();
var map = stage.LoadMap();
map.CanMoveTo(2,2);
var tile = sut.ElementAt(1, 1);
```

## Implementation

### Stage

Currently just contains hardcoded values for everything. Below you can see the implementation of 

```csharp
private readonly string _mapDescriptor =
@"==========
=!       =
=        =
=        =
=        =
=        =
=        =
=        =
=       *=
==========";
```

### Map

Under the hood is implemented as a single list. This is particularly easy then for reading in as characters and avoids multi-dimensional arrays. It does require a bit more maths than representing a grid using arrays.

```csharp
public enum ElementType
{
  Wall, PassageWay, Exit
}
```
