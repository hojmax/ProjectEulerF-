let divisorAmount number =
  let mutable n = number
  let mutable amount = 1
  let mutable i = 2
  while i <= int (sqrt (float n)) do
    let mutable power = 0
    while n % i = 0 do
      power <- power + 1
      n <- n / i
    amount <- amount * (power + 1)
    i <- i + 1
  if n <> 1 then
    amount <- amount * 2
  amount

let mutable triangleNumber = 1
let mutable addition = 2
while divisorAmount triangleNumber <= 500 do
  triangleNumber <- triangleNumber + addition
  addition <- addition + 1

printfn "%A" triangleNumber
