#include "Eyes.h"
#include "Wheels.h"

const int ACT_STOPPED = 0;
const int ACT_CRUISING = 1;
const int ACT_REVERSING = 2;
const int ACT_AVOIDING = 3;

const int COLLISION_WARNING_DISTANCE = 16;
const int COLLISION_CLEAR_DISTANCE = 17;
const int COLLISION_AVOIDANCE_TIME = 1000;

Wheels wheels(7,8,10,  5,4,3);
Eyes eyes(2, 11);

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
  
  //currentAction = ACT_CRUISING;
  //wheels.setSpeed(30);
  eyes.wake();
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
      wheels.setDirection(Wheels::STEER_LEFT);
      wheels.setSpeed(-100);
      avoidanceStartTime = millis();
    }
    if ((millis()-avoidanceStartTime) >= COLLISION_AVOIDANCE_TIME)
    {
      Serial.println("Turn complete");
      wheels.setDirection(Wheels::STEER_STRAIGHT);
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

    switch (incomingByte)
    {
    case '5': //stop motors
      Serial.println("Stopping");
      wheels.setSpeed(0);
      wheels.setDirection(Wheels::STEER_STRAIGHT);
      currentAction = ACT_STOPPED;
      break;

    case '8': // forwards
      Serial.println("forwards");
      wheels.setSpeed(1);
      wheels.setDirection(Wheels::STEER_STRAIGHT);
      currentAction = ACT_CRUISING;
      break;     

    case '2': // backwards
      Serial.println("backwards");
      wheels.setSpeed(-1);
      wheels.setDirection(Wheels::STEER_STRAIGHT);
      currentAction = ACT_CRUISING;
      break;     

    case '7': // left forward
      Serial.println("Left F");
      wheels.setSpeed(1);
      wheels.setDirection(Wheels::STEER_LEFT);
      currentAction = ACT_CRUISING;
      break;     

    case '1': // left backward
      Serial.println("Left R");
      wheels.setSpeed(Wheels::STEER_RIGHT);
      wheels.setDirection(1);
      currentAction = ACT_CRUISING;
      break;     

    case '9': // right forward
      Serial.println("Left F");
      wheels.setSpeed(1);
      wheels.setDirection(Wheels::STEER_LEFT);
      currentAction = ACT_CRUISING;
      break;     

    case '3': // right backward
      Serial.println("Left R");
      wheels.setSpeed(1);
      wheels.setDirection(Wheels::STEER_RIGHT);
      currentAction = ACT_CRUISING;
      break;     

    }

  }
}




