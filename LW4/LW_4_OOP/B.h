#pragma once
#include <iostream>
#include <iomanip>
using namespace std;

class B {
protected:
    int b;
public:
    B(int _b = 0) : b(_b) {
        cout << "Викликано конструктор B" << endl;
    }
    virtual void show() {
        cout << "b = " << b << "; ";
    }
    virtual ~B() {
        cout << "Викликано деструктор B" << endl;
    }
};