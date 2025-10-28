#include "Komplekt.h"

Komplekt::Komplekt(const std::string& name, double price, const std::vector<Produkt>& productList)
    : Tovar(name, price, "Комплект"), products(productList) {}

Komplekt::Komplekt() { type = "Комплект"; }

void Komplekt::init() {
    Tovar::init();
    int count;
    std::cout << "Скільки продуктів у комплекті?: ";
    std::cin >> count;
    products.clear();
    for (int i = 0; i < count; ++i) {
        Produkt p;
        std::cout << "\n--- Введення продукту #" << i + 1 << " для комплекту ---\n";
        p.init();
        products.push_back(p);
    }
}

void Komplekt::printAsRow() const {
    std::string components = std::to_string(products.size()) + " шт.";
    std::cout << "| " << std::setw(20) << std::left << name
        << "| " << std::setw(10) << type
        << "| " << std::setw(10) << price
        << "| " << std::setw(10) << "N/A"
        << "| " << std::setw(12) << "N/A"
        << "| " << std::setw(15) << "N/A"
        << "| " << std::setw(15) << components << "|\n";
    Tovar::printLine();
}

bool Komplekt::isExpired() const {
    for (const auto& product : products) {
        if (product.isExpired()) {
            return true;
        }
    }
    return false;
}