from collections import defaultdict


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


def getRelations(primes, magnitude):
    mag1 = 10**(magnitude-1)
    mag2 = 10**(magnitude-2)
    relations = defaultdict(set)
    for i in range(len(primes)):
        i1 = primes[i] // mag1
        i2 = primes[i] // mag2 % 10
        for j in range(i+1, len(primes)):
            j1 = primes[j] // mag1
            j2 = primes[j] // mag2 % 10
            if (i1 != i2 or j1 != j2) and j1 != i1 and j2 != i2:
                continue
            if hasRelation(primes[i], primes[j]):
                relations[primes[i]].add(primes[j])
                relations[primes[j]].add(primes[i])
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


def getCleanRelation(primes, goal, magnitude):
    relations = getRelations(primes, magnitude)
    lastLen = -1
    while lastLen != len(relations):
        while lastLen != len(relations):
            lastLen = len(relations)
            lengthWipe(relations, goal)
        intersectionWipe(relations, goal)
        lengthWipe(relations, goal)
    return relations


magnitude = 6
primes = primeSieve(10**(magnitude-1), 10**magnitude)
subsets = {1: [], 3: [], 7: [], 9: []}
goal = 8

for p in primes:
    subsets[p % 10].append(p)

for e in subsets:
    possible = getCleanRelation(subsets[e], goal, magnitude)
    if len(possible) > 0:
        print(possible)
        break
