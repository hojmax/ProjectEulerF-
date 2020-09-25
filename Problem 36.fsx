let digitAmount n =
  let mutable i = n
  let mutable result = 1
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

let isPalindromic n =
  let numberLength = digitAmount n
  let mutable palindromic = true
  let mutable i = 0
  let mutable leftMagnitude = pown 10 (numberLength - 1)
  let mutable rightMagnitude = 1
  while palindromic && i < numberLength / 2  do
    let left = n / leftMagnitude % 10
    let right = n / rightMagnitude % 10
    if not (left = right) then
      palindromic <- false
    else
      i <- i + 1
      leftMagnitude <- leftMagnitude / 10
      rightMagnitude <- rightMagnitude * 10
  palindromic

let rec toBinary value=
  if value < 2 then
    value.ToString()
  else
    let divisor = value / 2
    let remainder = (value % 2).ToString()
    toBinary divisor + remainder

let isBase2Palindromic value =
  let binaryNumber = toBinary value
  let mutable isPalindromic = true
  let mutable i = 0
  while isPalindromic && i < binaryNumber.Length / 2 do
    if binaryNumber.[i] <> binaryNumber.[binaryNumber.Length - i - 1] then
      isPalindromic <- false
    i <- i + 1
  isPalindromic

let mutable totalSum = 0
for i in 1 .. 2 .. int 1e6 - 1 do
  if isPalindromic i && isBase2Palindromic i then
    totalSum <- totalSum + i

printfn "%A" totalSum
