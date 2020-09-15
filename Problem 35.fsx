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

let digitsToNumber (digits: _ list) =
  let mutable output = 0
  for i in 0..digits.Length - 1 do
    output <- output + digits.[i] * (pown 10 (digits.Length - 1 - i))
  output

let numberToDigits number =
  let mutable n = number
  let mutable digits = []
  while n >= 1 do
    digits <- (n % 10) :: digits
    n <- n / 10
  digits

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

let primes = primeSieve 1000000
let mutable circularCount = 0

let isCircular number =
  let mutable digits = numberToDigits number
  let mutable i = 1
  let mutable stillUnsure = true
  while i <= digits.Length - 1 && stillUnsure do
    digits <- digits.[digits.Length - 1..digits.Length - 1] @ digits.[..digits.Length - 2]
    if not (isPrime (digitsToNumber digits)) then
      stillUnsure <- false
    i <- i + 1
  stillUnsure

for e in primes do
  if isCircular e then
    circularCount <- circularCount + 1

printfn "%A" circularCount
