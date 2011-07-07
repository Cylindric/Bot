#include "Eyes.h"
#include "Wheels.h"

const int ACT_STOPPED = 0;
const int ACT_CRUISING = 1;
const int ACT_REVERSING = 2;
const int ACT_AVOIDING = 3;

const int COLLISION_WARNING_DISTANCE = 16;
const int COLLISION_CLEAR_DISTANCE = 17;
const int COLLISION_AVOIDANCE_TIME = 1000;

Wheels wheels(7,8,10,  4,5,3);
Eyes eyes(2);

int incomingByte = 0;
int currentAction = ACT_STOPPED;
unsigned long avoidanceStartTime = 0;

void setup()
{
  Serial.begin(9600);
  Serial.println("Hello.");

  delay(1000);
  Serial.println("Ready!");
  Serial.flush();
  
  currentAction = ACT_CRUISING;
  wheels.setSpeed(30);
}

void loop()
{
  eyes.update();

  // If we're moving forwards and an obstacle is close begin avoidance routine
  if ( (eyes.getDistance() < COLLISION_WARNING_DISTANCE) && (currentAction == ACT_CRUISING) )
  {
    Serial.println("Object approaching");
    wheels.setSpeed(-100);
    currentAction = ACT_REVERSING;
  }

  // If we're moving backwards and an obstacle is out of range, go forwards
  if ( (eyes.getDistance() > COLLISION_CLEAR_DISTANCE) && (currentAction == ACT_REVERSING) )
  {
    Serial.println("Object clear");
    currentAction = ACT_AVOIDING;
  }
  
  // Need to turn to clear objects
  if (currentAction == ACT_AVOIDING)
  {
    if (avoidanceStartTime == 0)
    {
      Serial.println("Turning to avoid object");
      wheels.setDirection(-1);
      wheels.setSpeed(-100);
      avoidanceStartTime = millis();
    }
    if ((millis()-avoidanceStartTime) >= COLLISION_AVOIDANCE_TIME)
    {
      Serial.println("Turn complete");
      wheels.setDirection(0);
      avoidanceStartTime = 0;
      wheels.setSpeed(0);
      currentAction = ACT_CRUISING;
      wheels.setSpeed(255);
    }
  }
  
  wheels.update();

  if (Serial.available() > 0)
  {
    incomingByte = Serial.read();

    // stop
    switch (incomingByte)
    {
    case '0': //stop motors
      Serial.println("Stopping");
      wheels.setSpeed(0);
      currentAction = ACT_STOPPED;
      break;

    case '1': // full speed
      Serial.println("Starting");
      wheels.setSpeed(255);
      currentAction = ACT_CRUISING;
      break;     

    case 'S': // increase speed
      Serial.print("Increasing speed from ");
      Serial.print(wheels.getSpeed());
      Serial.println("...");
      wheels.setSpeed(wheels.getSpeed()+10);
      currentAction = ACT_CRUISING;
      break;

    case 's': // decrease speed
      Serial.print("Decreasing speed from ");
      Serial.print(wheels.getSpeed());
      Serial.println("...");
      wheels.setSpeed(wheels.getSpeed()-10);
      currentAction = ACT_STOPPED;
      break;

    case 'E': // ease in to speed
      Serial.println("Easing up to max speed");
      wheels.setSpeed(255, 2000);
      currentAction = ACT_CRUISING;
      break;

    case 'e': // ease out to speed
      Serial.println("Easing down to min speed");
      wheels.setSpeed(0, 2000);
      currentAction = ACT_STOPPED;
      break;
    }

  }
}




