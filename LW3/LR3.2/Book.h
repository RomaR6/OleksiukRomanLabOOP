#ifndef BOOK_H
#define BOOK_H
#include "PrintedEdition.h"

class Book : public PrintedEdition {
protected:
    std::string author;

public:
    Book(const std::string& title, int year, const std::string& author);
    Book();

    void init() override;
    void print() const override;
};
#endif 