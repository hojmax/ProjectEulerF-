let primeSieve n =
  let sieve = [|for i in 1..n / 2 -> 1|]
  let limit = int (sqrt (float n))
  for i in 1..(limit - 1) / 2 do
    if sieve.[i] = 1 then
      let value = 2 * i + 1
      for j in ((pown value 2) - 1) / 2 .. value .. sieve.Length - 1 do
        sieve.[j] <- 0
  let mutable result = []
  for i in sieve.Length - 1.. -1 .. 1 do
    if sieve.[i] = 1 then
      result <- (2 * i + 1) :: result
  2::result

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

let getDoubleSquares limit =
  let mutable output = []
  let mutable count = 1
  let mutable addition = 2 * pown count 2
  while addition < limit do
    output <- addition :: output
    count <- count + 1
    addition <- 2 * pown count 2
  output

let limit = 10000
let primes = primeSieve limit
let mutable candidates = Array.create (limit / 2) 1
let doubleSquares = getDoubleSquares limit
let mutable startingIndex = 0

for e in primes do
  while e + doubleSquares.[startingIndex] >= limit do
    startingIndex <- startingIndex + 1
  for i in startingIndex..doubleSquares.Length - 1 do
      candidates.[(e + doubleSquares.[i]) / 2] <- 0

for i in 1..candidates.Length - 1 do
  if candidates.[i] = 1 && not (isPrime (i * 2 + 1)) then
    printfn "%A" (i * 2 + 1)
