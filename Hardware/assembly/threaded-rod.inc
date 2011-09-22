#include "colors.inc"
#include "metals.inc"

#macro ThreadedRod(Diameter, Length)

    union{
        cylinder{
            0, 0.4*y, Diameter/2
        }
        cylinder{
            0.4*y, (Length-0.4)*y, Diameter/2
            texture {
                pigment {
                    spiral1 1
                    colour_map {
                        [0, rgb 0.4]
                        [0.2, rgb 0.4]
                        [1, rgb 0.2]
                    }
                }
                rotate 90*x
                scale (Diameter/10)*y
            }
        }
        cylinder{
            (Length-0.4)*y, Length*y, Diameter/2
        }
        pigment { color rgb 0.4}
    }

#end

#ifndef(LIVE_SCENE)
#version 3.7;
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <10, 40, -20>*0.5
    look_at <4, 5, 0>
}

Test_Sky()
Test_Ground()
object{ThreadedRod(2, 5) translate -5*x}
object{ThreadedRod(3, 8)}
object{ThreadedRod(4, 12) translate 7*x}
#end
