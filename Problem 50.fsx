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

let limit = int 1e6 - 1
let primes = primeSieve limit
let mutable interval = 2
let mutable bottomIndex = 0
let mutable shouldContinue = true
let mutable consecutivePrime = 0

while shouldContinue do
  let mutable sum = 0
  let mutable topIndex = bottomIndex + interval
  for i in bottomIndex..topIndex do sum <- sum + primes.[i]
  if sum > limit then
    shouldContinue <- false
  else
    while sum <= limit do
      if isPrime sum then
        interval <- topIndex - bottomIndex + 1 
        consecutivePrime <- sum
      topIndex <- topIndex + 1
      sum <- sum + primes.[topIndex]
  bottomIndex <- bottomIndex + 1

printfn "%A" consecutivePrime
