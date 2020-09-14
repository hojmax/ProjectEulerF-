let mutable fibonacci = [|1I; 1I|]
let mutable count = 2
let mutable limit = 1I

for i in 1..999 do
  limit <- limit * 10I

while fibonacci.[0] < limit do
  fibonacci <- [|fibonacci.[0] + fibonacci.[1]; fibonacci.[0]|]
  count <- count + 1

printfn "%A" count
