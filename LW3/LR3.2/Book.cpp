#include "Book.h"

Book::Book(const std::string& title, int year, const std::string& author)
    : PrintedEdition(title, year, " нига"), author(author) {}

Book::Book() { type = " нига"; }

void Book::init() {
    PrintedEdition::init();
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    std::cout << "¬вед≥ть автора: ";
    getline(std::cin, author);
}

void Book::print() const {
    std::cout << "| " << std::setw(25) << std::left << title
        << "| " << std::setw(15) << type
        << "| " << std::setw(10) << year
        << "| " << std::setw(20) << author
        << "| " << std::setw(15) << "N/A"
        << "| " << std::setw(10) << "N/A" << "|\n";
    printLine();
}