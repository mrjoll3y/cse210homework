#include <iostream>
#include <vector>
#include <fstream>
#include <string>
#include <iomanip>

class Task {
private:
    int id;
    std::string description;
    int priority;
    bool completed;

public:
    Task(int id, const std::string& description, int priority)
        : id(id), description(description), priority(priority), completed(false) {}

    void display() const {
        std::cout << std::setw(5) << id << " | "
                  << std::setw(20) << description << " | "
                  << std::setw(8) << priority << " | "
                  << (completed ? "Completed" : "Pending") << "\n";
    }

    void markComplete() { completed = true; }

    int getId() const { return id; }

    void saveToFile(std::ofstream& outFile) const {
        outFile << id << "|" << description << "|" << priority << "|" << completed << "\n";
    }

    static Task loadFromFile(const std::string& line) {
        std::istringstream stream(line);
        int id, priority;
        bool completed;
        std::string description;
        char delim;

        stream >> id >> delim;
        std::getline(stream, description, '|');
        stream >> priority >> delim >> completed;

        Task task(id, description, priority);
        if (completed) {
            task.markComplete();
        }
        return task;
    }
};

class ToDoList {
private:
    std::vector<Task> tasks;
    int nextId;

public:
    ToDoList() : nextId(1) {}

    void addTask(const std::string& description, int priority) {
        tasks.emplace_back(nextId++, description, priority);
    }

    void removeTask(int id) {
        for (auto it = tasks.begin(); it != tasks.end(); ++it) {
            if (it->getId() == id) {
                tasks.erase(it);
                std::cout << "Task " << id << " removed successfully.\n";
                return;
            }
        }
        std::cout << "Task " << id << " not found.\n";
    }

    void markTaskComplete(int id) {
        for (auto& task : tasks) {
            if (task.getId() == id) {
                task.markComplete();
                std::cout << "Task " << id << " marked as complete.\n";
                return;
            }
        }
        std::cout << "Task " << id << " not found.\n";
    }

    void displayTasks() const {
        std::cout << "\nCurrent Tasks:\n";
        std::cout << std::setw(5) << "ID" << " | "
                  << std::setw(20) << "Description" << " | "
                  << std::setw(8) << "Priority" << " | Status\n";
        std::cout << std::string(50, '-') << "\n";
        for (const auto& task : tasks) {
            task.display();
        }
    }

    void saveToFile(const std::string& filename) const {
        std::ofstream outFile(filename);
        if (!outFile) {
            std::cerr << "Error saving tasks to file.";
            return;
        }
        for (const auto& task : tasks) {
            task.saveToFile(outFile);
        }
        std::cout << "Tasks saved to " << filename << " successfully.\n";
    }

    void loadFromFile(const std::string& filename) {
        std::ifstream inFile(filename);
        if (!inFile) {
            std::cerr << "Error loading tasks from file.";
            return;
        }

        tasks.clear();
        std::string line;
        while (std::getline(inFile, line)) {
            tasks.push_back(Task::loadFromFile(line));
        }
        std::cout << "Tasks loaded from " << filename << " successfully.\n";
    }
};

int main() {
    ToDoList list;
    std::string filename = "tasks.txt";
    list.loadFromFile(filename);

    int choice;
    do {
        std::cout << "\nTo-Do List Manager:\n";
        std::cout << "1. Add Task\n2. Remove Task\n3. Mark Task Complete\n4. Display Tasks\n5. Save and Exit\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        switch (choice) {
        case 1: {
            std::string description;
            int priority;
            std::cout << "Enter task description: ";
            std::cin.ignore();
            std::getline(std::cin, description);
            std::cout << "Enter task priority (1-10): ";
            std::cin >> priority;
            list.addTask(description, priority);
            break;
        }
        case 2: {
            int id;
            std::cout << "Enter task ID to remove: ";
            std::cin >> id;
            list.removeTask(id);
            break;
        }
        case 3: {
            int id;
            std::cout << "Enter task ID to mark complete: ";
            std::cin >> id;
            list.markTaskComplete(id);
            break;
        }
        case 4:
            list.displayTasks();
            break;
        case 5:
            list.saveToFile(filename);
            std::cout << "Goodbye!\n";
            break;
        default:
            std::cout << "Invalid choice. Please try again.\n";
        }
    } while (choice != 5);

    return 0;
}

