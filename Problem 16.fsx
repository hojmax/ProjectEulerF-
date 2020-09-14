let mutable a = 1I
for i in 1..1000 do
  a <- 2I * a

let mutable total = 0I
while a >= 1I do
  total <- total + a % 10I
  a <- a / 10I

printfn "%A" total
