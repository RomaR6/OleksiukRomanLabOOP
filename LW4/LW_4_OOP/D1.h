#pragma once
#include "B.h"

class D1 : public virtual B {
protected:
    int d1;
public:
    D1(int _b = 0, int _d1 = 0) : B(_b), d1(_d1) {
        cout << "Викликано конструктор D1" << endl;
    }
    virtual void show() override {
        cout << "d1 = " << d1 << "; ";
    }
    ~D1() {
        cout << "Викликано деструктор D1" << endl;
    }
};