#include "Komplekt.h"
#include <sstream>

Komplekt::Komplekt() {
    type = "Комплект";
}

void Komplekt::init() {
    Tovar::init();
    int count;
    std::cout << "Скільки продуктів у комплекті?: ";
    std::cin >> count;
    products.clear();
    for (int i = 0; i < count; ++i) {
        auto p = std::make_unique<Produkt>();
        std::cout << "\n--- Введення продукту #" << i + 1 << " для комплекту ---\n";
        p->init();
        products.push_back(std::move(p));
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
        if (product->isExpired()) {
            return true;
        }
    }
    return false;
}

std::string Komplekt::getComponentsInfo() const {
    if (products.empty()) {
        return "0 шт.";
    }
    std::stringstream ss;
    ss << "Складається з " << products.size() << " шт.: ";
    for (size_t i = 0; i < products.size(); ++i) {
        ss << products[i]->getName() << (i == products.size() - 1 ? "" : ", ");
    }
    return ss.str();
}