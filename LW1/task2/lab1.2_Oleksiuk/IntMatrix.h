#pragma once
#include <iostream>
using namespace std;

class IntMatrix
{
private:
    int** IntArray;
    int n;

public:
    IntMatrix(int size);
    ~IntMatrix();

    void input();
    void output();
    int sumOfColumn(int col) const;
    int getZeroCount() const;
    void setMainDiagonal(int value);
};
