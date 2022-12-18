#include <iostream>
#include <vector>

using namespace std;

class object{
public:
    object(){
        cout << "Конструктор по умолчанию класса object" << endl;
    }

    ~object() {
        cout << "Диструктор класса object" << endl;
    }
    virtual void name_yourself(){
        cout << "yooou Object" << endl;
    }
};


class Animal : public object{
public :
    Animal(){
        cout << "Конструктор по умолчанию абстрактного класса Animal" << endl;
    }
    void sound() {
        printf ("\n") ;
    }
    virtual void name_yourself(){
        cout << "yooou Animal" << endl;
    }

};

class Cat : public Animal{
protected:
    string coat_color;
    string breed;
public :
    Cat(): coat_color("gray"),breed("British cat"){
        cout << "Конструктор по умолчанию класса Cat" << endl;
    }
    Cat(string coat_color,string breed): coat_color(coat_color),breed(breed){
        cout << "Конструктор с параметрами класса Cat" << endl;
    }

    void sound() {
        printf ("Mew−mew␣\n") ;
    }
    void catchMouse(){
        cout << "``` Звуки охоты кошки ```" << endl;
    }

    void name_yourself(){
        cout << "I am is a cat" << endl;
    }
    ~Cat() {
        cout << "Работа диструктора класса Car" << endl;
    }
};

class Dog : public Animal {
protected:
    string coat_color;
    string breed;
public :
    Dog(): coat_color("gray"),breed("British cat"){
        cout << "Конструктор по умолчанию класса Dog" << endl;
    }
    Dog(string coat_color,string breed): coat_color(coat_color),breed(breed){
        cout << "Конструктор с параметрами класса Dog" << endl;
    }

    void sound() {
        printf ("Gaf - gaf␣\n") ;
    }
    void chaseCat(){
        cout << "``` звуки погони собаки за котом ```" << endl;
    }
    void name_yourself(){
        cout << "I am is a dog" << endl;
    }
    ~Dog() {
        cout << "Работа диструктора класса Dog" << endl;
    }
};

class ground_vehicle : public object{
protected:
    int number_of_wheels;
    string color;
public:
    ground_vehicle(): number_of_wheels(4),color("white"){
        cout << "Конструктор по умолчанию класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }
    ground_vehicle(int number_of_wheels,string color): number_of_wheels(number_of_wheels),color(color){
        cout << "Конструктор с параметрами класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  this -> number_of_wheels << ", color: " << this -> color << endl;
        cout << "\n";
    }
    ground_vehicle(const ground_vehicle &vehicle): number_of_wheels(vehicle.number_of_wheels),color(vehicle.color){
        cout << "Конструктор копирования класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }

    void go_straight(){
        cout << "``` is going straight ```" << endl;
    }

    void name_yourself(){
        cout << "I am is a vehicle" << endl;
    }

    ~ground_vehicle(){
        cout << "Диструктор класса ground_vehicle:" << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }

};


int main() {
    

    object* object_1 = new Cat("White","British");
    object* object_2 = new Dog("Black","Bulderer");
    object* object_3 = new Dog();
    object* object_4 = new Dog("White","British");
    object* object_5 = new ground_vehicle();


  


    return 0;
}
