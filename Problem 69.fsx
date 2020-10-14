let floatPrimeSieve n =
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
      result <- float (2 * i + 1) :: result
  List.toArray (2.0::result)

// https://en.wikipedia.org/wiki/Euler%27s_totient_function#Computing_Euler's_totient_function
let phi n factors = Array.fold (fun a e -> a * (1.0 - 1.0 / e)) n factors

let limit = int 1e6
let primes = floatPrimeSieve limit

let getPrimeFactors number =
  let mutable output = []
  let mutable index = 0
  while index < primes.Length && primes.[index] <= number do
    if number % primes.[index] = 0.0 then
      output <- primes.[index] :: output
    index <- index + 1
  List.toArray output

let upper = int (sqrt (float limit))
let mutable maxValue = 0.0
let mutable maxN = 0
let totients = Array.create (limit - 1) -1.0

// Lidt langsom. Tager omkring 105 sekunder at udføre, men får jobbet klaret.
for n in 2 .. limit do
  if totients.[n - 2] = -1.0 then
    let factors = getPrimeFactors (float n)
    totients.[n - 2] <- float n / (phi (float n) factors)
    let mutable i = 2
    while i < n && i * n <= limit do
      if not (Array.exists (fun e -> (float i) % e = 0.0) factors) then
        totients.[i * n - 2] <- totients.[i - 2] * totients.[n - 2]
      i <- i + 1
  if totients.[n - 2] > maxValue then
    maxValue <- totients.[n - 2]
    maxN <- n

printfn "%A" maxN
