import time
startTime = time.time()


def primeSieve(minVal, n):
    prime = [True for i in range(n + 1)]
    output = []
    p = 2
    while (p * p <= n):
        if (prime[p] == True):
            for i in range(p * p, n + 1, p):
                prime[i] = False
        p += 1
    for p in range(max(minVal, 2), n + 1):
        if prime[p]:
            output.append(p)
    return output


def digitAmount(n):
    result = 1
    if n >= 100000000:
        result += 8
        n /= 100000000
    if n >= 10000:
        result += 4
        n /= 10000
    if n >= 100:
        result += 2
        n /= 100
    if n >= 10:
        result += 1
        n /= 10
    return result


def hasRelation(n1, n2):
    # Assuming digitAmount(n1) == digitAmount(n2)
    diff1 = -1
    diff2 = -1
    while n1 > 0:
        if n1 % 10 != n2 % 10:
            if diff1 == -1:
                diff1 = n1 % 10
                diff2 = n2 % 10
            elif diff1 != n1 % 10 or diff2 != n2 % 10:
                return False
        n1 //= 10
        n2 //= 10
    return True


def addRelation(n1, n2, relations):
    if n1 in relations:
        relations[n1].add(n2)
    else:
        relations[n1] = {n2}
    if n2 in relations:
        relations[n2].add(n1)
    else:
        relations[n2] = {n1}


def getRelations(primes, magnitude):
    mag1 = 10**(magnitude-1)
    mag2 = 10**(magnitude-2)
    relations = dict()
    for i in range(len(primes)):
        if i % 1000 == 0: 
            print(i/len(primes)*100,"%")
        i1 = primes[i] // mag1
        i2 = primes[i] // mag2 % 10
        for j in range(i+1, len(primes)):
            j1 = primes[j] // mag1
            j2 = primes[j] // mag2 % 10
            if (i1 != i2 or j1 != j2) and j1 != i1 and j2 != i2:
                continue
            if hasRelation(primes[i], primes[j]):
                addRelation(primes[i], primes[j], relations)
    return relations


def lengthWipe(relations, goal):
    toRemove = []
    for e in relations:
        if len(relations[e]) < goal-1:
            for n in relations[e]:
                relations[n].remove(e)
            toRemove.append(e)
    for e in toRemove:
        relations.pop(e, None)


def intersectionWipe(relations, goal):
    removalPairs = []
    for e in relations:
        for f in relations[e]:
            if len(relations[e].intersection(relations[f])) < goal-2:
                removalPairs.append([e, f])
    for e in removalPairs:
        relations[e[0]].remove(e[1])

magnitude = 6
primes = primeSieve(10**(magnitude-1), 10**magnitude)
goal = 8
relations = getRelations(primes, magnitude)
print("Relations!")
lastLen = -1

while lastLen != len(relations):
    while lastLen != len(relations):
        lastLen = len(relations)
        lengthWipe(relations, goal)
    intersectionWipe(relations,goal)
    lengthWipe(relations, goal)

print(relations)

print("**** Runtime: {} seconds ****".format(round(time.time() - startTime, 2)))
