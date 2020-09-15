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

let primeSieve n =
  let sieve = [|for i in 1..n / 2 -> 1|]
  let limit = int (sqrt (float n))
  for i in 1..(limit - 1) / 2 do
    if sieve.[i] = 1 then
      let value = 2 * i + 1
      for j in ((pown value 2) - 1) / 2 .. value .. sieve.Length - 1 do
        sieve.[j] <- 0
  let mutable result = [2]
  for i in 1..sieve.Length - 1 do
    if sieve.[i] = 1 then
      result <- (2 * i + 1) :: result
  result

let isTruncatable number =
  let mutable n = number
  let mutable isUnsure = true
  while isUnsure && n >= 10 do
    n <- n / 10
    isUnsure <- isPrime n
  if isUnsure then
    n <- number
    let mutable digits = digitAmount number
    while isUnsure && n >= 10 do
      n <- n - n / (pown 10 (digits - 1)) * (pown 10 (digits - 1))
      isUnsure <- isPrime n
      digits <- digits - 1
  isUnsure

let primes = primeSieve (int 1e6)
let mutable truncatableSum = 0
for e in primes do
  if e > 9 && isTruncatable e then
    truncatableSum <- truncatableSum + e
    
printfn "%A" truncatableSum
