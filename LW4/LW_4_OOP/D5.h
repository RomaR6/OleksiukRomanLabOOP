#pragma once
#include "D1.h"
#include "D2.h"
#include "D3.h"

class D5 : public D1, public D2, private D3 {
protected:
    int d5;
public:
    D5(int _b = 0, int _d1 = 0, int _d2 = 0, int _d3 = 0, int _d5 = 0)
        : B(_b), D1(_b, _d1), D2(_b, _d2), D3(_b, _d3), d5(_d5) {
        cout << "Викликано конструктор D5" << endl;
    }

    virtual void show() override {
        B::show();
        D1::show();
        D2::show();
        D3::show();
        cout << "d5 = " << d5 << "; ";
    }
    ~D5() {
        cout << "Викликано деструктор D5" << endl;
    }
};