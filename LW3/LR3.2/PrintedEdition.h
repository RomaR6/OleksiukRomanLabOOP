#ifndef PRINTED_EDITION_H
#define PRINTED_EDITION_H

#include <iostream>
#include <string>
#include <iomanip>
#include <limits>

class PrintedEdition {
protected:
    std::string title;
    int year;
    std::string type;

public:
    PrintedEdition(const std::string& title, int year, const std::string& type);
    PrintedEdition();
    virtual ~PrintedEdition() {}

    virtual void init();
    virtual void print() const = 0;

    static void printHeader();
    static void printLine();

    std::string getTitle() const { return title; }
};

#endif 