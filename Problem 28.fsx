let mutable gridSize = 1001
gridSize <- gridSize + 2
let mutable grid = [|for i in 1..gridSize -> [|for i in 1..gridSize -> 0|]|]
let mutable count = 1
let mutable x = gridSize / 2
let mutable y = gridSize / 2
let mutable dirX = 1
let mutable dirY = 0
let mutable moveLength = 1

let print2dArray (array: int[][]) =
  for i in 0..array.Length-1 do
    printfn "%A" array.[i]

while count < pown (gridSize - 2) 2 do
  for j in 0..1 do
    for i in 0..moveLength-1 do
      grid.[y].[x] <- count
      x <- x + dirX
      y <- y + dirY
      count <- count + 1
    let temp = dirX
    dirX <- -dirY
    dirY <- temp
  moveLength <- moveLength + 1

let mutable total = -1
for i in 0..gridSize-3 do
  total <- total + grid.[1+i].[1+i] + grid.[gridSize - 2 - i].[1 + i]

printfn "%A" total
