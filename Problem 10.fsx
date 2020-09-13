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

let mutable total = 5L
let mutable i = 1
while i * 6 - 1 < int 2e6 do
  for delta in -1 .. 2 .. 1 do
    if isPrime (i * 6 + delta) then
      total <- total + int64 (i * 6 + delta)
  i <- i + 1

printfn "%A" total
