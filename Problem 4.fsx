let digitAmount n =
  let mutable i = n
  let mutable result = 1
  if i >= 100000000 then
    result <- result + 8
    i <- i / 100000000
  if i >= 10000 then
    result <- result + 4
    i <- i / 10000
  if i >= 100 then
    result <- result + 2
    i <- i / 100
  if i >= 10 then
    result <- result + 1
    i <- i / 10
  result

let print x =
  printfn "%A" x

let isPalindromic n =
  let numberLength = digitAmount n
  let mutable palindromic = true
  let mutable i = 0
  while palindromic && i < numberLength / 2  do
    let left = (n / (pown 10 (numberLength-i-1)))%10
    let right = n / (pown 10 i) % 10
    if not (left = right) then
      palindromic <- false
    i <- i + 1
  palindromic

// 900*(900+1)/2 = 405450
let candidates = Array.create 405450 0
let mutable index = 0
for i in 100..999 do
  for j in i..999 do
    candidates.[index] <- i * j
    index <- index + 1

let mutable highest = 0
for i in 0..candidates.Length-1 do
  if isPalindromic candidates.[i] && candidates.[i] > highest then
    highest <- candidates.[i]

print highest
