let distinctPrimeFactorCount number =
  let mutable n = number
  let mutable factorCount = 0
  let mutable i = 0I
  while i <= (System.Numerics.BigInteger (sqrt (float n)) + 1I) / 6I do
    let candidates = if i = 0I then [|2I; 3I|] else [|6I * i - 1I; 6I * i + 1I|]
    for e in candidates do
      let mutable primeFactor = false
      while n % e = 0I do
        n <- n / e
        primeFactor <- true
      if primeFactor then
        factorCount <- factorCount + 1
    i <- i + 1I
  if n <> 1I then
    factorCount <- factorCount + 1
  factorCount

let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
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
      result <- (2I * System.Numerics.BigInteger i + 1I) :: result
  2I::result

let primes = primeSieve 500
let maxPower = 3I
let mutable candidates = []

let rec fillCandidates number index amount =
// Fandt 253894 på en tidligere søgning, men det var ikke det korrekte svar. Derfor kan jeg nu sætte den som øvre grænse.
  if number < 253894I then
    if amount = 4 then
      candidates <- number :: candidates
    else if amount < 4 then
      for i in index..primes.Length - 1 do
        for j in 1I..maxPower do
          fillCandidates (number * iPown primes.[i] j) (i + 1) (amount + 1)

fillCandidates 1I 0 0
candidates <- List.sort candidates

for e in candidates do
  let mutable isUnsure = true
  let mutable i = 1I
  while isUnsure && i <= 3I do
    isUnsure <- distinctPrimeFactorCount (e + i) = 4
    i <- i + 1I
  if isUnsure then
    printfn "%A" e
