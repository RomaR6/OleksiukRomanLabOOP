#ifndef PARTIA_H
#define PARTIA_H
#include "Tovar.h"

class Partia : public Tovar {
private:
    int quantity;
    time_t productionDate;
    int expiryDays;
public:
    Partia(const std::string& name, double price, int qty, time_t prodDate, int expDays);
    Partia();

    void init() override;
    void printAsRow() const override;
    bool isExpired() const override;
};
#endif 