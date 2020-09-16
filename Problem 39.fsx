let integerTriangleSolutions n =
  let mutable amountOfSolutions = 0
  for a in 1..n / 3 - 1 do
    let mutable b = a + 1
    let mutable c = n - a - b
    let powA = pown a 2
    while c > b do
        if powA + pown b 2 = pown c 2 then
          amountOfSolutions <- amountOfSolutions + 1
        b <- b + 1
        c <- n - a - b
  amountOfSolutions

let mutable maxSolutions = 0
let mutable maxNumber = 0
for i in 1..1000 do
  let solutions = integerTriangleSolutions i
  if solutions > maxSolutions then
    maxSolutions <- solutions
    maxNumber <- i

printfn "%A" maxNumber
