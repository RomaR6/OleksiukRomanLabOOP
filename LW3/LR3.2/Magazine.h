#ifndef MAGAZINE_H
#define MAGAZINE_H
#include "PrintedEdition.h"

class Magazine : public PrintedEdition {
private:
    std::string publisher;
    int issueNumber;

public:
    Magazine(const std::string& title, int year, const std::string& publisher, int issueNumber);
    Magazine();

    void init() override;
    void print() const override;
};
#endif 