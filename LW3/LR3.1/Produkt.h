#ifndef PRODUKT_H
#define PRODUKT_H
#include "Tovar.h"

class Produkt : public Tovar {
private:
    time_t productionDate;
    int expiryDays;

public:
    Produkt(const std::string& name, double price, time_t prodDate, int expDays);
    Produkt();

    void init() override;
    void printAsRow() const override;
    bool isExpired() const override;
};
#endif 