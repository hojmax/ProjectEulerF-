#include <iostream>
#include <cmath>
using namespace std;

bool isPrime(int n) {
    if (n == 2 || n == 3) {
        return true;
    } else if (n < 2 || n % 2 == 0 || n % 3 == 0) {
        return false;
    } else {
        bool isPrime = true;
        const int limit = ((int) sqrt(n) + 1) / 6;
        int i = 1;
        while (i <= limit && isPrime) {
            if (n % (6 * i + 1) == 0 || n % (6 * i - 1) == 0) {
                isPrime = false;
            }
            i++;
        }
        return isPrime;
    }
}

int main() {
    int i = 1;
    int primes = 0;
    int delta = 2;
    while (true) {
        for (int j = 0; j < 4; j++) {
            i += delta;
            if (isPrime(i)) {
                primes++;
            }
        }
        if ((float) primes / (delta * 2 + 1) < 0.1) {
            break;
        }
        delta += 2;
    }
    cout << "Side length: " << delta + 1 << endl;
}
