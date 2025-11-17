#include "Sklad.h"
#include <iostream>

Sklad::Sklad(const std::string& n) : name(n) {}

void Sklad::AddItem(Tovar* item) {
    if (item) {
        items.push_back(item);
        std::cout << "Товар '" << item->getName() << "' додано до складу '" << name << "'.\n";
    }
}

void Sklad::ShowContents() const {
    if (items.empty()) {
        std::cout << "\nСклад '" << name << "' порожній.\n";
        return;
    }

    std::cout << "\n--- ВМІСТ СКЛАДУ '" << name << "' ---\n";
    Tovar::printHeader();
    for (const auto& item : items) {
        item->printAsRow();
    }
}

std::string Sklad::getName() const {
    return name;
}

bool Sklad::containsItem(const Tovar* item) const {
    for (const auto& storedItem : items) {
        if (storedItem == item) {
            return true;
        }
    }
    return false;
}