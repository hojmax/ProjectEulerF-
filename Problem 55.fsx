let digitAmount n =
  let mutable i = n
  let mutable result = 1I
  if i >= 10000000000000000I then
    result <- result + 16I
    i <- i / 10000000000000000I
  if i >= 100000000I then
    result <- result + 8I
    i <- i / 100000000I
  if i >= 10000I then
    result <- result + 4I
    i <- i / 10000I
  if i >= 100I then
    result <- result + 2I
    i <- i / 100I
  if i >= 10I then
    result <- result + 1I
    i <- i / 10I
  result

let iPown a b =
  let mutable result = 1I
  for i in 1I..b do
    result <- result * a
  result

let isPalindromic n =
  let numberLength = digitAmount n
  let mutable palindromic = true
  let mutable i = 0I
  while palindromic && i < numberLength / 2I  do
    let left = (n / (iPown 10I (numberLength - i - 1I))) % 10I
    let right = n / (iPown 10I i) % 10I
    if not (left = right) then
      palindromic <- false
    i <- i + 1I
  palindromic

let reverseNumber number =
  let mutable digits = digitAmount number
  let mutable result = 0I
  let mutable n = number
  while n >= 1I do
    result <- result + (n % 10I) * iPown 10I (digits - 1I)
    n <- n / 10I
    digits <- digits - 1I
  result

let isLychrel number =
  let mutable isUnsure = true
  let mutable currentNumber = number
  let mutable iterations = 0
  while isUnsure && iterations < 50 do
    currentNumber <- currentNumber + reverseNumber currentNumber
    if isPalindromic currentNumber then
      isUnsure <- false
    else
      iterations <- iterations + 1
  isUnsure

let mutable lychrelCount = 0

for i in 1I..9999I do
    if isLychrel i then
      lychrelCount <- lychrelCount + 1

printfn "%A" lychrelCount
