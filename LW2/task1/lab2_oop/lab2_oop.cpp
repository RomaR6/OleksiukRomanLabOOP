#include <iostream>
#include "IntMatrix.h"
using namespace std;

int main()
{
    IntMatrix m1(2), m2(2);

    cout << "Fill matrix m1:\n";
    m1.input();
    cout << "Fill matrix m2:\n";
    m2.input();

    cout << "\nMatrix m1:\n"; m1.output();
    cout << "\nMatrix m2:\n"; m2.output();

    // ++ --
    cout << "\nApplying ++ to m1:\n";
    ++m1;
    m1.output();

    cout << "\nApplying -- to m2:\n";
    m2--;
    m2.output();

    // +
    cout << "\nMatrix m1 + m2:\n";
    IntMatrix sum = m1 + m2;
    sum.output();

    // bool
    if (m1) cout << "\nm1 is square!\n";

    // string conversion
    string str = string(m1);
    cout << "\nMatrix m1 as string:\n" << str << endl;

    IntMatrix m3 = IntMatrix::fromString(str);
    cout << "\nMatrix m3 (restored from string):\n";
    m3.output();

    return 0;
}
