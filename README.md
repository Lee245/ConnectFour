# ConnectFour
Connect Four is a game in which two players strategically (or not ;)) drop tokens in a `6 * 7` board with the aim to get 4 tokens of the same colour in a line (either horizontally, vertically or diagonally). It is a special case of the more general `m,n,k`-game where two players try to get `k` tokens in a line on an `m * n` board.

## Dependencies
See instructions on how to install (open source) .NET on Linux [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux) (can be installed via the regular package manager for popular distros such as Fedora and Ubuntu).

## How to View
You can use VSCode or VSCodium (open source) for easy viewing of the solution (or just use Github).

## How to Run
From the command-line, assuming you're in the root folder of this project:
`dotnet run --project ConnectFour/`

To run the unit tests execute:
`dotnet test`
