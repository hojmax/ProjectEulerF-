let numberLetters = Map.empty.Add(0, 0).Add(1, 3).Add(2, 3).Add(3, 5).Add(4, 4)
                             .Add(5, 4).Add(6, 3).Add(7, 5).Add(8, 5).Add(9, 4)
                             .Add(10, 3).Add(20, 6).Add(30, 6).Add(40, 5).Add(50, 5)
                             .Add(60, 5).Add(70, 7).Add(80, 6).Add(90, 6).Add(100, 10)
                             .Add(200, 10).Add(300, 12).Add(400, 11).Add(500, 11).Add(600, 10)
                             .Add(700, 12).Add(800, 12).Add(900, 11).Add(1000, 11)
let deltaTeens = Map.empty.Add(14,1).Add(16,1).Add(17,1).Add(19,1)

let numberToLetters number =
  // Specialtilfælde "and"
  let mutable letterCount = if number >= 100 && number % 100 <> 0 then 3 else 0
  if deltaTeens.ContainsKey(number % 100) then
    letterCount <- letterCount + deltaTeens.[number % 100]
  let mutable digits = digitAmount number
  let mutable n = number
  while digits >= 1 do
    let magnitude = pown 10 (digits - 1)
    letterCount <- letterCount + numberLetters.[n / magnitude * magnitude]
    n <- n % magnitude
    digits <- digits - 1
  letterCount

let mutable total = 0
for i in 1..1000 do
  total <- total + numberToLetters i

printfn "%A" total
