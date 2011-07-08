#include "Wheels.h"

Wheels wheels(7,8,10,  4,5,3);

int testPhase = 0;
unsigned long phaseTime = 0;

void setup()
{
  Serial.begin(9600);
  Serial.println("Hello.");
  delay(1000);
  Serial.println("Ready!");
  Serial.flush();
  phaseTime = millis();
}

void loop()
{
  wheels.update();

  if ((millis() - phaseTime) > 1000)
  {
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
    }

    testPhase++;
  }
}




