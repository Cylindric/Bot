#include "Wheels.h"

Wheels wheels(7,8,10,  4,5,3);

int testPhase = 0;
unsigned long phaseTime = 0;
unsigned long phaseDelay = 0;
const unsigned long defaultPhaseDelay = 1000;

void setup()
{
  Serial.begin(9600);
  Serial.println("Hello.");
  delay(1000);
  Serial.println("Ready!");
  Serial.flush();
}

void loop()
{
  wheels.update();

  if ((millis() - phaseTime) > phaseDelay)
  {
    phaseDelay = defaultPhaseDelay; // reset phaseDelay to default
    switch (testPhase)
    {
      case (0):
        Serial.println("Full forward");
        wheels.setSpeed(255);
        break;

      case (1):
        Serial.println("Full stop");
        wheels.setSpeed(0);
        break;
      
      case (2):
        Serial.println("Full backwards");
        wheels.setSpeed(-255);
        break;
        
      case (3):
        Serial.println("Reset for easing tests");
        wheels.setSpeed(0);
        break;
        
      case (4):
        Serial.println("Ease up to max forward speed over 5 seconds");
        wheels.setSpeed(255, 5000);
        phaseDelay = 6000;
        break;
        
      case (5):
        Serial.println("Ease down to zero speed over 5 seconds");
        wheels.setSpeed(0, 5000);
        phaseDelay = 6000;
        break;
      
      case (6):
        Serial.println("Ease from max forward to max reverse over 5 seconds (part 1)");
        wheels.setSpeed(255);
        break;

      case (7):
        Serial.println("Ease from max forward to max reverse over 5 seconds (part 2)");
        wheels.setSpeed(-255, 5000);
        phaseDelay = 6000;
        break;

      default:
        Serial.println("Done");
        wheels.setSpeed(0);
        testPhase = 9999;
        break;
    }
    testPhase++;
  }
}




