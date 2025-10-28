#ifndef LIBRARY_H
#define LIBRARY_H
#include "PrintedEdition.h"
#include <vector>
#include <memory>

class Library {
private:
    
    static std::vector<std::unique_ptr<PrintedEdition>> stock;

public:
    
    static void Add(PrintedEdition* edition);
    static void ShowAll();
    static void FindByTitle(const std::string& title);
};

#endif 