let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

let digitalSum number =
  let mutable n = number
  let mutable total = 0I
  while n >= 1I do
    total <- total + n % 10I
    n <- n / 10I
  total

let mutable maxDigitalSum = 0I
for a in 1I..99I do
  for b in 1I..99I do
    let current = digitalSum (iPown a b)
    if current > maxDigitalSum then
      maxDigitalSum <- current

printfn "%A" maxDigitalSum
