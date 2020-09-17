let factorial number =
  let mutable total = 1I
  for i in 2I..number do
    total <- total * i
  total

let combinations n r =
  (factorial n) / ((factorial r) * (factorial (n - r)))

let mutable total1M = 0I

for n in 2I .. 100I do
  let mutable index = n / 2I
  let mutable over1M = 0I
  while combinations n index > 1000000I do
    over1M <- over1M + 2I
    index <- index - 1I
  if over1M > 0I && n % 2I = 0I then
    over1M <- over1M - 1I
  total1M <- total1M + over1M

printfn "%A" total1M
