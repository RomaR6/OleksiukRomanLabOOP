#include "Textbook.h"

Textbook::Textbook(const std::string& title, int year, const std::string& author, const std::string& subject, int grade)
    : Book(title, year, author), subject(subject), grade(grade) {
    type = "Підручник";
}

Textbook::Textbook() { type = "Підручник"; }

void Textbook::init() {
    Book::init(); 
    std::cout << "Введіть предмет: ";
    getline(std::cin, subject);
    std::cout << "Введіть клас (цифрою): ";
    std::cin >> grade;
}

void Textbook::print() const {
    std::cout << "| " << std::setw(25) << std::left << title
        << "| " << std::setw(15) << type
        << "| " << std::setw(10) << year
        << "| " << std::setw(20) << author
        << "| " << std::setw(15) << subject
        << "| " << std::setw(10) << grade << "|\n";
    printLine();
}