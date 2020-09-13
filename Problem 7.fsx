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

let mutable i = 1
let mutable primeCount = 2
while primeCount < 10001 do
  for delta in -1 .. 2 .. 1 do
    if isPrime (i * 6 + delta) then
      primeCount <- primeCount + 1
      if primeCount = 10001 then
        printfn "%A" (i * 6 + delta)
  i <- i + 1
