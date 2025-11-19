#include "Database.h"

std::vector<std::unique_ptr<Tovar>> Database::items;

void Database::Add(std::unique_ptr<Tovar> item) {
    items.push_back(std::move(item));
}

void Database::ShowAll() {
    if (items.empty()) {
        std::cout << "Áàçà äàíèõ ïîðîæíÿ." << std::endl;
        return;
    }

    Tovar::printHeader();
    for (const auto& item : items) {
        item->printAsRow();
    }
}

void Database::FindExpired() {
    bool found = false;
    for (const auto& item : items) {
        if (item->isExpired()) {
            found = true;
            break;
        }
    }

    if (!found) {
        std::cout << "Ïðîñòðî÷åíèõ òîâàð³â íå çíàéäåíî." << std::endl;
        return;
    }

    std::cout << "\nÇÍÀÉÄÅÍÎ ÏÐÎÑÒÐÎ×ÅÍ² ÒÎÂÀÐÈ:\n";
    Tovar::printHeader();
    for (const auto& item : items) {
        if (item->isExpired()) {
            item->printAsRow();
        }
    }
}

const std::vector<std::unique_ptr<Tovar>>& Database::getItems() {
    return items;
} 