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

let mutable allDigits = 0
let mutable i = 1
let mutable currentLimit = 1
let mutable fractionMult = 1
while allDigits < 1000000 do
  allDigits <- allDigits + digitAmount i
  if allDigits >= currentLimit then
    let mutable n = i
    for j in 1..allDigits - currentLimit do
      n <- n / 10
    fractionMult <- fractionMult * (n % 10)
    currentLimit <- currentLimit * 10
  i <- i + 1
