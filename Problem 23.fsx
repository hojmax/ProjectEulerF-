let properDivisorSum n =
  let mutable total = 1
  let root = sqrt (float n)
  for i in 2..int root do
    if n % i = 0 then
      total <- total + i + n / i
  if root % 1.0 = 0.0 then
    total <- total - int root
  total

let limit = 28123
let mutable numberSum = limit*(limit+1)/2
let mutable abundantNumbers = [||]
let mutable removedNumbers = Set.empty

for i in 12..limit do
  if properDivisorSum i > i then
    abundantNumbers <- Array.append abundantNumbers [|i|]

for i in 0..abundantNumbers.Length-1 do
  for j in i..abundantNumbers.Length-1 do
    let num = abundantNumbers.[i] + abundantNumbers.[j]
    if num <= limit && not (removedNumbers.Contains(num)) then
      numberSum <- numberSum - num
      removedNumbers <- removedNumbers.Add(num)

printfn "%A" numberSum
