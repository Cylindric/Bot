#ifndef Face_h
#define Face_h

class Face
{
  public:
    Face();
    void update();
    
  private:
    unsigned long _lastUpdate;
    int _updateInterval;
};


#endif

