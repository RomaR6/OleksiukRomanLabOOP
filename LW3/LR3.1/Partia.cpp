#include "Partia.h"

Partia::Partia(const std::string& name, double price, int qty, time_t prodDate, int expDays)
    : Tovar(name, price, "Партія"), quantity(qty), productionDate(prodDate), expiryDays(expDays) {}

Partia::Partia() : Tovar(), quantity(0), productionDate(0), expiryDays(0) { type = "Партія"; }

void Partia::init() {
    Tovar::init();
    std::cout << "Введіть кількість у партії: ";
    std::cin >> quantity;
    int y, m, d;
    std::cout << "Введіть дату виробництва (Рік Місяць День): ";
    std::cin >> y >> m >> d;
    productionDate = create_date(y, m, d);
    std::cout << "Введіть термін придатності (днів): ";
    std::cin >> expiryDays;
}

void Partia::printAsRow() const {
    std::cout << "| " << std::setw(20) << std::left << name
        << "| " << std::setw(10) << type
        << "| " << std::setw(10) << price
        << "| " << std::setw(10) << quantity
        << "| " << std::setw(12) << time_t_to_string(productionDate)
        << "| " << std::setw(15) << expiryDays
        << "| " << std::setw(15) << "N/A" << "|\n";
    Tovar::printLine();
}

bool Partia::isExpired() const {
    if (productionDate == 0) return false;
    time_t now = time(0);
    time_t expiryDate = productionDate + (expiryDays * 24 * 60 * 60);
    return now > expiryDate;
}