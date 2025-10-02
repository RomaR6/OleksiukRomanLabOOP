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
    IntMatrix(const IntMatrix& other);
    IntMatrix& operator=(const IntMatrix& other);
    ~IntMatrix();

    void input();
    void output() const;
    int sumOfColumn(int col) const;
    int getZeroCount() const;
    void setMainDiagonal(int value);

    
    IntMatrix operator+(const IntMatrix& other) const;
    IntMatrix operator-(const IntMatrix& other) const;
    IntMatrix& operator++();     
    IntMatrix operator++(int);   
    IntMatrix& operator--();     
    IntMatrix operator--(int);   
    bool operator==(const IntMatrix& other) const;

    friend ostream& operator<<(ostream& os, const IntMatrix& m);
};
