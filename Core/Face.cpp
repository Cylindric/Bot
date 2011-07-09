#include <WProgram.h>
#include "Face.h"

Face::Face()
{
  _lastUpdate = 0;
  _updateInterval = 1000;
}      


void Face::update()
{  
  if ((millis() - _lastUpdate) > _updateInterval)
  {
    // update the display
    _lastUpdate = millis();
  }
}


