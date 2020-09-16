let iPown a b =
  let mutable output = 1I
  for i in 1I..b do
    output <- output * a
  output

let mutable total = 0I
for i in 1I..1000I do
  total <- total + iPown i i

printfn "%A" (total % 10000000000I)
