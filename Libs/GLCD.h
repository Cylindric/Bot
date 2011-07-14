#ifndef GLCD_h
#define GLCD_h
#include <WProgram.h>

class GLCD
{
  private:
    uint8_t _GLCDPin;

  public:
    GLCD();
    void attach(uint8_t dataPin);
    void clear();
    void setXY(uint8_t x, uint8_t y);
    void setPixel(uint8_t x, uint8_t y, bool state);
    void setLine(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state);
    void setCircle(uint8_t x, uint8_t y, uint8_t r, bool state);
    void setBox(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state);
    void eraseBlock(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state);
    void demo();
    void toggleReverse();
    void toggleSplash();
    void setBacklight(uint8_t brightness);
    void sendCommand(uint8_t data);

};

#endif
