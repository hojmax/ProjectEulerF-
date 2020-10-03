let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

let precision = 1000I
let magnitude = iPown 10I precision

let findCycleLength number =
  let decimals = magnitude / number
  let mutable divMagnitude = magnitude / 10I
  let identifiers = [for i in 0I..2I -> decimals / (divMagnitude / iPown 10I i) % 10I]
  let mutable counter = 0
  while divMagnitude >= 1000I &&
       (decimals / (divMagnitude / 10I) % 10I <> identifiers.[0] ||
        decimals / (divMagnitude / 100I) % 10I <> identifiers.[1] || 
        decimals / (divMagnitude / 1000I) % 10I <> identifiers.[2]) do
    divMagnitude <- divMagnitude / 10I
    counter <- counter + 1
  if divMagnitude > 100I then
    counter + 1
  else
    -1

let mutable longestCycle = 0
let mutable correspondingNumber = 0I
for i in 11I..999I do
  let cycleLength = findCycleLength i
  if cycleLength > longestCycle then
    longestCycle <- cycleLength
    correspondingNumber <- i

printfn "%A" correspondingNumber
