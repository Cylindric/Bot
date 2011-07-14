#ifndef Eyes_h
#define Eyes_h

class Eyes
{
  public:
    Eyes(int pingPin, int neckPin);
    void update();
    void wake();
    int getDistance();
    
  private:
    int _pingPin;
    int _neckPin;
    int _distance;
    unsigned long _lastPing;
    static const int _pingInterval = 100;
};


#endif
