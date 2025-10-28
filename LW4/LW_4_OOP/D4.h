#pragma once
#include "D1.h"

class D4 : private D1 {
protected:
    int d4;
public:
    D4(int _b = 0, int _d1 = 0, int _d4 = 0)
        : B(_b), D1(_b, _d1), d4(_d4) {
        cout << "Викликано конструктор D4" << endl;
    }

    virtual void show() override {
        B::show();
        D1::show();
        cout << "d4 = " << d4 << "; ";
    }
    ~D4() {
        cout << "Викликано деструктор D4" << endl;
    }
};