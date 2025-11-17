#ifndef KOMPLEKT_H
#define KOMPLEKT_H

#include "Tovar.h"
#include <vector>
#include <memory>
#include <string>
#include "Produkt.h"

class Komplekt : public Tovar {
private:
    std::vector<std::unique_ptr<Produkt>> products;

public:
    Komplekt();
    void init() override;
    void printAsRow() const override;
    bool isExpired() const override;
    std::string getComponentsInfo() const;
};
#endif