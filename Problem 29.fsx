let mutable possible = Set.empty

let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

for a in 2I..100I do
  for b in 2I..100I do
    possible <- possible.Add(iPown a b)

printfn "%A" possible.Count
