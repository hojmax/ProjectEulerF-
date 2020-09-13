let limit = 100
let mutable sumOfSquares = 0
let squareOfSum = pown (limit*(limit+1)/2) 2

for i in 1..limit do
  sumOfSquares <- sumOfSquares + i * i

printfn "%A" (squareOfSum - sumOfSquares)
