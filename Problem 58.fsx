let mutable gridSize = 26243
let mutable grid = [|for i in 1..gridSize -> [|for i in 1..gridSize -> 0|]|]
let mutable count = 1
let mutable x = gridSize / 2
let mutable y = gridSize / 2
let mutable dirX = 1
let mutable dirY = 0
let mutable moveLength = 1

let isPrime n =
  if n = 2 || n = 3 then
    true
  else
    if n < 2 || n % 2 = 0 || n % 3 = 0 then
      false
    else
      let mutable prime = true
      let limit = (int (sqrt (float n)) + 1) / 6
      let mutable i = 1
      while i <= limit && prime do
        if n % (6 * i + 1) = 0 || n % (6 * i - 1) = 0 then
          prime <- false
        i <- i + 1
      prime

let addSpiralPart () =
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

for i in 1..3 do
  addSpiralPart ()

let mutable ringCount = 1
let mutable primeCount = 3

while (float primeCount) / (float (1 + 4 * ringCount)) > 0.1 do
  for i in 1..2 do
    addSpiralPart ()
  ringCount <- ringCount + 1
  let candidates = [|grid.[gridSize / 2 - ringCount].[gridSize / 2 - ringCount];
                     grid.[gridSize / 2 - ringCount].[gridSize / 2 + ringCount];
                     grid.[gridSize / 2 + ringCount].[gridSize / 2 + ringCount];
                     grid.[gridSize / 2 + ringCount].[gridSize / 2 - ringCount];|]
  for e in candidates do
    if isPrime e then
      primeCount <- primeCount + 1

printfn "%A" (ringCount * 2 + 1)
