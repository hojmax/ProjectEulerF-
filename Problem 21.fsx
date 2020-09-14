let properDivisorSum n =
  let mutable total = 1
  let root = sqrt (float n)
  for i in 2..int root do
    if n % i = 0 then
      total <- total + i + n / i
  if root % 1.0 = 0.0 then
    total <- total - int root
  total

let mutable total = 0
let mutable ruledOut = Set.empty
for i in 3..10000 do
  if not (ruledOut.Contains(i)) then
    let pairNumber = properDivisorSum i
    if i = properDivisorSum pairNumber && not (i = pairNumber) then
      total <- total + i + pairNumber
      ruledOut <- ruledOut.Add(i)
      ruledOut <- ruledOut.Add(pairNumber)

printfn "%A" total
