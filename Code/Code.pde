#include <SoftwareSerial.h>

#include "Antenna.h"
#include "Eyes.h"
#include "Wheels.h"

Antenna antenna(2, 3);
Wheels wheels(9, 10);
Eyes eyes(7);

int incomingByte = 0;

void setup()
{
  Serial.begin(9600);
  Serial.println("Hello.");
  delay(2000);
  Serial.println("Ready!");
}

void loop()
{
  eyes.update();
//  antenna.update();
  
  // if we're parked, then tapping the antenna starts us up
  //if ((antenna.triggered() == true) && (wheels.getSpeed() == 0))
//  if (antenna.triggered() == true)
//  {
//    if (wheels.getSpeed() == 0)
//    {
//      Serial.println("Setting off...");
//      wheels.setSpeed(255, 5000);
//    }
//    else
//    {
//      Serial.println("Hit something!");
//      wheels.setSpeed(0);
//    }
//  }
  
  if (eyes.getDistance() < 5)
  {
    if (wheels.getSpeed() > 0)
    {
      Serial.println("Object approaching too close!");
      wheels.setSpeed(0, 200);
    }
  }

  wheels.update();

//  antenna.reset();

  if (Serial.available() > 0)
  {
    incomingByte = Serial.read();

    // stop
    switch (incomingByte)
    {
    case '0': //stop motors
      Serial.println("Stopping");
      wheels.setSpeed(0);
      break;

    case '1': // full speed
      Serial.println("Starting");
      wheels.setSpeed(255);
      break;     

    case 'S': // increase speed
      Serial.print("Increasing speed from ");
      Serial.print(wheels.getSpeed());
      Serial.println("...");
      wheels.setSpeed(wheels.getSpeed()+10);
      break;

    case 's': // decrease speed
      Serial.print("Decreasing speed from ");
      Serial.print(wheels.getSpeed());
      Serial.println("...");
      wheels.setSpeed(wheels.getSpeed()-10);
      break;

    case 'E': // ease in to speed
      Serial.println("Easing up to max speed");
      wheels.setSpeed(255, 2000);
      break;

    case 'e': // ease out to speed
      Serial.println("Easing down to min speed");
      wheels.setSpeed(0, 2000);
      break;
    }

  }
}



