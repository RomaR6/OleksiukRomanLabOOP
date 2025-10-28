#ifndef KOMPLEKT_H
#define KOMPLEKT_H
#include "Tovar.h"
#include <vector>
#include "Produkt.h"

class Komplekt : public Tovar {
private:
    std::vector<Produkt> products;

public:
    Komplekt(const std::string& name, double price, const std::vector<Produkt>& productList);
    Komplekt();

    void init() override;
    void printAsRow() const override;
    bool isExpired() const override;
};
#endif 