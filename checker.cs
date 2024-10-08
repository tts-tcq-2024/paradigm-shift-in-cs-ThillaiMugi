using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
class Checker
{
    static bool batteryIsOk(float temperature, float soc, float chargeRate) {
        bool temperatureCheck = temperatureIsOk(temperature);
        bool socCheck = socIsOk(soc);
        bool chargeRateCheck = chargeRateIsOk(chargeRate);
        return temperatureCheck && socCheck && chargeRateCheck;
    }

    static bool temperatureIsOk(float temperature){
        if(temperature < 0 || temperature > 45 ) {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }
        return true;
    }

    static bool socIsOk(float soc){
        if(soc < 20 || soc > 80) {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        } 
        return true;
    }

    static bool chargeRateIsOk(float chargeRate){
         if(chargeRate > 0.8) {
            Console.WriteLine("Charge Rate is out of range!");
            return false;
        }
        return true;
    }

    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        
        ExpectFalse(batteryIsOk(-10, 30, 0.5f));
        ExpectFalse(batteryIsOk(40, -5, 0.3f));
        ExpectFalse(batteryIsOk(35, 25, 4.0f));
        
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
