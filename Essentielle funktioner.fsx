let primeFactors number =
  let mutable n = number
  let mutable result = []
  let mutable i = 2
  while i <= int (sqrt (float n)) do
    while n % i = 0 do
      result <- i :: result
      n <- n / i
    i <- i + 1
  if not (n = 1) then
    result <- n :: result
  result

// Kan udvides til at kunne håndtere større tal
let digitAmount n =
  let mutable i = n
  let mutable result = 1
  if i >= 100000000 then
    result <- result + 8
    i <- i / 100000000
  if i >= 10000 then
    result <- result + 4
    i <- i / 10000
  if i >= 100 then
    result <- result + 2
    i <- i / 100
  if i >= 10 then
    result <- result + 1
    i <- i / 10
  result

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

// Til at teste performance:
let stopWatch = System.Diagnostics.Stopwatch.StartNew()
// Kode her
stopWatch.Stop()
printfn "*** Millis: %A ***" (int stopWatch.Elapsed.TotalMilliseconds)
