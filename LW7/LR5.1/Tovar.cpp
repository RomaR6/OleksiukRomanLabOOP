#define _CRT_SECURE_NO_WARNINGS
#include "Tovar.h"

void Tovar::init() {
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    std::cout << "Введіть назву: ";
    getline(std::cin, name);
    std::cout << "Введіть ціну: ";
    std::cin >> price;
}

void Tovar::printHeader() {
    printLine();
    std::cout << "| " << std::setw(20) << std::left << "Назва"
        << "| " << std::setw(10) << "Тип"
        << "| " << std::setw(10) << "Ціна"
        << "| " << std::setw(10) << "К-сть"
        << "| " << std::setw(12) << "Дата вир-ва"
        << "| " << std::setw(15) << "Термін (днів)"
        << "| " << std::setw(15) << "Склад комплекту" << "|\n";
    printLine();
}

void Tovar::printLine() {
    std::cout << std::setfill('-') << std::setw(104) << "" << std::setfill(' ') << std::endl;
}

std::string time_t_to_string(time_t time) {
    if (time == 0) return "N/A";
    char buffer[80];
    strftime(buffer, sizeof(buffer), "%Y-%m-%d", localtime(&time));
    return std::string(buffer);
}

time_t create_date(int year, int month, int day) {
    tm timeinfo = { 0 };
    timeinfo.tm_year = year - 1900;
    timeinfo.tm_mon = month - 1;
    timeinfo.tm_mday = day;
    return mktime(&timeinfo);
}