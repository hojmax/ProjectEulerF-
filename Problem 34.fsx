let factorial number =
  let mutable total = 1
  for i in 2..number do
    total <- total * i
  total

let precomputedFactorials = [|for i in 0..9 -> factorial i|]

let digitFactorial number =
  let mutable n = number
  let mutable total = 0
  while n >= 1 do
    total <- total + preComputedFactorials.[n % 10]
    n <- n / 10
  total

let mutable total = 0
// Kan max være 7-cifrede tal, da 8 * 9! = 2903040, hvilket ikke er 8-cifret
for i in 3..9999999 do
  if digitFactorial i = i then
    total <- total + i

printfn "%A" total
