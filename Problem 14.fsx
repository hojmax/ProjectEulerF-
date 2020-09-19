// Der er mange udregninger af de samme kæder
// Men jeg har prøvet, og det kan ikke svare sig tidsmæssigt at holde styr på de tidligere beregnede tal

let getChainLength number =
  let mutable count = 1
  let mutable n = number
  while n <> 1I do
    if n % 2I = 0I then
      n <- n / 2I
    else
      n <- 3I * n + 1I
    count <- count + 1
  count

let mutable longest = 0
let mutable startingNumber = 0I
for i in 1I..999999I do
  let chainLength = getChainLength i
  if chainLength > longest then
    longest <- chainLength
    startingNumber <- i

printfn "%A" startingNumber
