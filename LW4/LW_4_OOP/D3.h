#pragma once
#include "B.h"

class D3 : private virtual B {
protected:
    int d3;
public:
    D3(int _b = 0, int _d3 = 0) : B(_b), d3(_d3) {
        cout << "Викликано конструктор D3" << endl;
    }
    virtual void show() override {
        cout << "d3 = " << d3 << "; ";
    }
    ~D3() {
        cout << "Викликано деструктор D3" << endl;
    }
};