#ifndef TOVAR_H
#define TOVAR_H

#include <iostream>
#include <string>
#include <ctime>
#include <iomanip>
#include <limits>

class Tovar {
protected:
    std::string name;
    double price;
    std::string type;

public:
    Tovar(const std::string& n, double p, const std::string& t) : name(n), price(p), type(t) {}
    Tovar() : name("N/A"), price(0.0), type("N/A") {}
    virtual ~Tovar() {}

    virtual void init();
    virtual void printAsRow() const = 0;
    virtual bool isExpired() const = 0;

    static void printHeader();
    static void printLine();

    std::string getName() const { return name; }
};

std::string time_t_to_string(time_t time);
time_t create_date(int year, int month, int day);

#endif 