#include "IntMatrix.h"
#include <iostream>
using namespace std;

IntMatrix::IntMatrix(int size) : n(size)
{
    IntArray = new int* [n];
    for (int i = 0; i < n; ++i)
        IntArray[i] = new int[n] {};
}

IntMatrix::~IntMatrix()
{
    for (int i = 0; i < n; ++i)
        delete[] IntArray[i];
    delete[] IntArray;
}

void IntMatrix::input()
{
    cout << "Enter elements of the matrix (" << n << "x" << n << "):\n";
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j) {
            cout << "Element [" << i << "][" << j << "]: ";
            cin >> IntArray[i][j];
        }
}

void IntMatrix::output()
{
    cout << "Matrix elements:\n";
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j)
            cout << IntArray[i][j] << " ";
        cout << endl;
    }
}

int IntMatrix::sumOfColumn(int col) const
{
    if (col < 0 || col >= n) {
        cout << "Column index out of bounds.\n";
        return 0;
    }
    int sum = 0;
    for (int i = 0; i < n; ++i)
        sum += IntArray[i][col];
    return sum;
}

int IntMatrix::getZeroCount() const
{
    int count = 0;
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            if (IntArray[i][j] == 0)
                ++count;
    return count;
}

void IntMatrix::setMainDiagonal(int value)
{
    for (int i = 0; i < n; ++i)
        IntArray[i][i] = value;
}
