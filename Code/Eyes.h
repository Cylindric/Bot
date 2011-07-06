#ifndef Eyes_h
#define Eyes_h

class Eyes
{
  public:
    Eyes(int pingPin);
    void update();
    int getDistance();
    
  private:
    int _pingPin;
    int _distance;
    unsigned long _lastPing;
    static const int _pingInterval = 500;
};


#endif
