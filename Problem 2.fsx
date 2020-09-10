let mutable a = 1
let mutable b = 0
let mutable result = 0

while a + b < int 4e6 do
  let hold = a
  a <- a + b
  b <- hold
  if a % 2 = 0 then
    result <- result + a

printfn "%A" result
