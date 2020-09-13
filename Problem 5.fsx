// Den her opgave har ikke behov for programmering
// Vi starter med tallet x som en øvre grænse:
// 1 * 2 * 3 * 4 * 5 * 6 *7 * 8 * 9 * 10 * 11 * 12 * 13 * 14 * 15 * 16 * 17 * 18 * 19 * 20
// Nu kan man dele tallene x op i dens primfaktorer:
// x = 1 * 2 * 3 * (2*2) * 5 * (2*3) * 7 * (2*2*2) * (3*3) * (2*5) * 11 * (2*6) * 13 * (2*7) * (3*5) * (2*2*2*2) * 17 * (2*9) * 19 * (2*2*5)
// Men som det kan ses er der f.eks. maksimalt brug for at x er deleligt med 2, 4 gange (her er 16 det begrænsende tal).
// Alle andre forekomster af primfaktoren 2 er overflødig. Ved samme logik for de andre tal kan udtrykket forsimples til:
// x = 2*2*2*2 * 3*3 * 5 * 7 * 11 * 13 * 17 * 19 = 232792560
