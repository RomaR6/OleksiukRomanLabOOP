#pragma once
#include "B.h"

class D2 : private virtual B {
protected:
    int d2;
public:
    D2(int _b = 0, int _d2 = 0) : B(_b), d2(_d2) {
        cout << "Викликано конструктор D2" << endl;
    }
    virtual void show() override {
        cout << "d2 = " << d2 << "; ";
    }
    ~D2() {
        cout << "Викликано деструктор D2" << endl;
    }
};