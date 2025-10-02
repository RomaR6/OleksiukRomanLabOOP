#include <iostream>
#include "IntMatrix.h"
using namespace std;

int main()
{
    IntMatrix m1(2), m2(2);

    cout << "Fill m1:\n"; m1.input();
    cout << "Fill m2:\n"; m2.input();

    cout << "\nMatrix m1:\n" << m1;
    cout << "\nMatrix m2:\n" << m2;

    cout << "\nSum m1 + m2:\n" << (m1 + m2);
    cout << "\nDiff m1 - m2:\n" << (m1 - m2);

    cout << "\nApplying ++m1:\n" << ++m1;
    cout << "\nApplying m2--:\n" << m2--;

    if (m1 == m2)
        cout << "\nMatrices are equal\n";
    else
        cout << "\nMatrices are different\n";

    cout << "\nZeros in m1: " << m1.getZeroCount() << endl;

    cout << "Setting diagonal to 7...\n";
    m1.setMainDiagonal(7);
    cout << m1;

    return 0;
}
