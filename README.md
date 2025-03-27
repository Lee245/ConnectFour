# ConnectFour
Connect Four is a game in which players strategically (or not) drop tokens in a `6 * 7` board with the aim to get 4 tokens of the same colour in a line (either horizontally, vertically or diagonally). It is a special case of the more general `m,n,k`-game where players try to get `k` tokens in a line on a `m * n` board.

## Dependencies
See instructions on how to install (open source) .NET on Linux [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux).

## How to Run
From the command-line, assuming you're in the root folder of this project:
`dotnet run --project ConnectFour/`

To run the unit tests execute:
`dotnet run --project ConnectFourTest/`
