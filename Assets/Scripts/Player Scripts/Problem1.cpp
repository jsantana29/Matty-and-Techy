
//Problem one

#include <iostream>

using namespace std;

int main()
{
    int grade = 0;

    cout << "Please enter a grade: " << endl;
    cin >> grade;

    if (grade >= 70)
    {
        cout << "Pass" << endl;
    }
    else
    {
        cout << "Fail" << endl;
    }

    cout << "Finish" << endl;
    return 0;
}
