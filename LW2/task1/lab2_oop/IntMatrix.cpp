#include "IntMatrix.h"
#include <stdexcept>

IntMatrix::IntMatrix(int size) : n(size)
{
    IntArray = new int* [n];
    for (int i = 0; i < n; ++i)
        IntArray[i] = new int[n] {};
}

IntMatrix::IntMatrix(const IntMatrix& other) : n(other.n)
{
    IntArray = new int* [n];
    for (int i = 0; i < n; ++i) {
        IntArray[i] = new int[n];
        for (int j = 0; j < n; ++j)
            IntArray[i][j] = other.IntArray[i][j];
    }
}

IntMatrix& IntMatrix::operator=(const IntMatrix& other)
{
    if (this == &other) return *this;

    for (int i = 0; i < n; ++i) delete[] IntArray[i];
    delete[] IntArray;

    n = other.n;
    IntArray = new int* [n];
    for (int i = 0; i < n; ++i) {
        IntArray[i] = new int[n];
        for (int j = 0; j < n; ++j)
            IntArray[i][j] = other.IntArray[i][j];
    }
    return *this;
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

void IntMatrix::output() const
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
    if (col < 0 || col >= n)
        throw out_of_range("Invalid column index");

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

// ---------- Перевантаження операторів ----------
IntMatrix IntMatrix::operator+(const IntMatrix& other) const
{
    if (n != other.n) throw invalid_argument("Matrix sizes must match");
    IntMatrix result(n);
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            result.IntArray[i][j] = IntArray[i][j] + other.IntArray[i][j];
    return result;
}

IntMatrix IntMatrix::operator-(const IntMatrix& other) const
{
    if (n != other.n) throw invalid_argument("Matrix sizes must match");
    IntMatrix result(n);
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            result.IntArray[i][j] = IntArray[i][j] - other.IntArray[i][j];
    return result;
}

IntMatrix& IntMatrix::operator++()
{
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            ++IntArray[i][j];
    return *this;
}

IntMatrix IntMatrix::operator++(int)
{
    IntMatrix temp(*this);
    ++(*this);
    return temp;
}

IntMatrix& IntMatrix::operator--()
{
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            --IntArray[i][j];
    return *this;
}

IntMatrix IntMatrix::operator--(int)
{
    IntMatrix temp(*this);
    --(*this);
    return temp;
}

bool IntMatrix::operator==(const IntMatrix& other) const
{
    if (n != other.n) return false;
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            if (IntArray[i][j] != other.IntArray[i][j])
                return false;
    return true;
}

ostream& operator<<(ostream& os, const IntMatrix& m)
{
    for (int i = 0; i < m.n; ++i) {
        for (int j = 0; j < m.n; ++j)
            os << m.IntArray[i][j] << " ";
        os << endl;
    }
    return os;
}
