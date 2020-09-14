let digitFithPower number =
  let mutable sum = 0
  let mutable n = number
  while n >= 1 do
    sum <- sum + pown (n % 10) 5
    n <- n / 10
  sum

let mutable total = 0
for i in 2..999999 do
  if i = digitFithPower i then
    total <- total + i
    printfn "%A" i

printfn "%A" total

// Jeg ved at jeg ikke behøves at kigge højere end 6-cifrede tal (Maks 999999)
// I det bedste scenerie er det bestående af udelukkende 9-taller
// Men ved 7 * 9 ** 5 = 413343, altså et 6-cifret tal.
// Siden tallene vækster hurtigere end potens-summen, ved jeg at 7-cifrede tal eller højere ikke kan forekomme.
