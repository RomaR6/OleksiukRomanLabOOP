#pragma once
#include <iostream>
#include <string>
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

    
    IntMatrix& operator++();   
    IntMatrix operator++(int); 
    IntMatrix& operator--();   
    IntMatrix operator--(int); 

    operator bool() const; 

    IntMatrix operator+(const IntMatrix& other) const;

    operator string() const;                
    static IntMatrix fromString(const string& str); 
};
