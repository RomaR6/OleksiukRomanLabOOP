#include "Library.h"
#include <iostream>

std::vector<std::unique_ptr<PrintedEdition>> Library::stock;

void Library::Add(PrintedEdition* edition) {
    stock.emplace_back(edition);
}

void Library::ShowAll() {
    if (stock.empty()) {
        std::cout << "Бібліотека порожня.\n";
        return;
    }
    PrintedEdition::printHeader();
    for (const auto& edition : stock) {
        edition->print();
    }
}

void Library::FindByTitle(const std::string& title) {
    bool found = false;
    for (const auto& edition : stock) {
        if (edition->getTitle() == title) {
            if (!found) {
                std::cout << "\nЗнайдено такі видання:\n";
                PrintedEdition::printHeader();
                found = true;
            }
            edition->print();
        }
    }
    if (!found) {
        std::cout << "Видання з назвою \"" << title << "\" не знайдено.\n";
    }
}