// Dette her problem kræver heller ingen programmering for at løse. 
// Man skal blot indse at det er et kombinatorik problem i forklædning.
// For at nå hjørnet i en n x n kvadrat må man gå n skridt nedad og n skridt mod højre.
// Det vil sige er at vi leder efter hvor mange forskellige rækkefølger man kan tage disse skridt
// Vi forestiller os en række af binære tal af længden 2n (0 for nedad, 1 for udad)
// Ved at vende halvdelen om til 1'ere vil man have en sekvens af step ned til udgangen
// Nu skal vi altså finde antal kombinationer af udvælgelser af denne sekvens når rækkefølgen ikke har betydning
// Dette gøres med følgende ligning: K(n,r)=n!/(r!(n-r)!)
// Løsningen er altså: K(40,20)=40!/(20!(40-20)!)=137846528820
