#ifndef Antenna_h
#define Antenna_h

class Antenna
{
  public:
    Antenna(int leftAntenna, int rightAntenna);

    void update();
    bool triggered();
    bool touching();
    void reset();
    
  private:
    int _leftAntenna;
    int _rightAntenna;
    bool _leftState;
    bool _rightState;
    bool _triggered;
};


#endif