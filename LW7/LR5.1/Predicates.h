#pragma once
#include "Tovar.h"
#include <string>

class FindByNamePred {
private:
    std::string name;
public:
    FindByNamePred(std::string n) : name(n) {}
    bool operator()(Tovar* t) {
        return t->getName() == name;
    }
};

class PriceSorterDesc {
public:
    bool operator()(Tovar* a, Tovar* b) {
        return a->getPrice() > b->getPrice();
    }
};

class PriceSorterAsc {
public:
    bool operator()(Tovar* a, Tovar* b) {
        return a->getPrice() < b->getPrice();
    }
};