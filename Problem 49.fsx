let intervalPrimeSieve m n =
  let sieve = [|for i in 1..n / 2 -> 1|]
  let limit = int (sqrt (float n))
  for i in 1..(limit - 1) / 2 do
    if sieve.[i] = 1 then
      let value = 2 * i + 1
      for j in ((pown value 2) - 1) / 2 .. value .. sieve.Length - 1 do
        sieve.[j] <- 0
  let mutable result = if 2 >= m then [2] else []
  for i in 1..sieve.Length - 1 do
    if sieve.[i] = 1 && 2 * i + 1 >= m then
      result <- (2 * i + 1) :: result
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

let interval = 3330
let candidates = intervalPrimeSieve 1000 (9999 - 2 * interval)
for e in candidates do
  let mutable originalDigits = [|for i in 0..9 -> 0|]
  let mutable n = e
  let mutable isUnsure = true
  while n >= 1 do
    originalDigits.[n % 10] <- originalDigits.[n % 10] + 1
    n <- n / 10
  let mutable i = 1
  while isUnsure && i <= 2 do
      let equalDigitsCheck = Array.copy originalDigits
      let mutable m = e + i * interval
      isUnsure <- isPrime m
      while isUnsure && m >= 1 do
        equalDigitsCheck.[m % 10] <- equalDigitsCheck.[m % 10] - 1
        if equalDigitsCheck.[m % 10] < 0 then
          isUnsure <- false
        else
          m <- m / 10
      i <- i + 1
  if isUnsure then
    printfn "%A %A %A" e (e + interval) (e + 2 * interval)
