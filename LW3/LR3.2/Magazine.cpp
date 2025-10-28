#include "Magazine.h"

Magazine::Magazine(const std::string& title, int year, const std::string& publisher, int issueNumber)
    : PrintedEdition(title, year, "∆урнал"), publisher(publisher), issueNumber(issueNumber) {}

Magazine::Magazine() { type = "∆урнал"; }

void Magazine::init() {
    PrintedEdition::init();
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    std::cout << "¬вед≥ть видавництво: ";
    getline(std::cin, publisher);
    std::cout << "¬вед≥ть номер випуску: ";
    std::cin >> issueNumber;
}

void Magazine::print() const {
    std::cout << "| " << std::setw(25) << std::left << title
        << "| " << std::setw(15) << type
        << "| " << std::setw(10) << year
        << "| " << std::setw(20) << publisher
        << "| " << std::setw(15) << issueNumber
        << "| " << std::setw(10) << "N/A" << "|\n";
    printLine();
}