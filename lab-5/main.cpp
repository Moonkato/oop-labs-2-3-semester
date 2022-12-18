#include <iostream>

using namespace std;


class animal{
public:
   animal(){
        cout << " animal() " << endl;
    }


    void method_1(){
       cout << "method_1 animal" << endl;
       method_2();
   }

   virtual void method_2(){
       cout << "method_2 animal" << endl;
   }

   void method_3(){
       cout << "method_3 animal" << endl;
   }


    virtual ~animal(){
         cout << " ~animal() " << endl;
    }
};

class cat: public animal{
private:
    string hair_color;

public:
    cat(): hair_color("gray"){
        cout << " cat() " << endl;
    }

    void method_2() override{
        cout << "method_2 cat " << endl;
    }

    void method_3(){
        cout << "method_3 cat " << endl;
    }

    ~cat(){
        cout << " ~cat() " << endl;
    }
};



class vehicle{
protected:
    int amount_of_wheels;

public:
    virtual void horn_sound() = 0;

    virtual string classname(){
        return "vehicle";
    }
    virtual bool isa(const string &who){
        return who == "vehicle";
    }
    virtual void open_trunk(){

    };
};



int main() {

    
    return 0;
}
