#ifndef TEXTBOOK_H
#define TEXTBOOK_H
#include "Book.h" 

class Textbook : public Book {
private:
    std::string subject;
    int grade; 

public:
    Textbook(const std::string& title, int year, const std::string& author, const std::string& subject, int grade);
    Textbook();

    void init() override;
    void print() const override;
};
#endif 