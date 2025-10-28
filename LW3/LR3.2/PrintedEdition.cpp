#include "PrintedEdition.h"
#include "Library.h"

PrintedEdition::PrintedEdition(const std::string& title, int year, const std::string& type)
    : title(title), year(year), type(type) {
    Library::Add(this); 
}

PrintedEdition::PrintedEdition() : title("N/A"), year(0), type("N/A") {}

void PrintedEdition::init() {
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    std::cout << "Введіть назву: ";
    getline(std::cin, title);
    std::cout << "Введіть рік видання: ";
    std::cin >> year;
}

void PrintedEdition::printHeader() {
    printLine();
    std::cout << "| " << std::setw(25) << std::left << "Назва"
        << "| " << std::setw(15) << "Тип"
        << "| " << std::setw(10) << "Рік"
        << "| " << std::setw(20) << "Автор / Видавець"
        << "| " << std::setw(15) << "Предмет / Номер"
        << "| " << std::setw(10) << "Клас" << "|\n";
    printLine();
}

void PrintedEdition::printLine() {
    std::cout << std::setfill('-') << std::setw(108) << "" << std::setfill(' ') << std::endl;
}