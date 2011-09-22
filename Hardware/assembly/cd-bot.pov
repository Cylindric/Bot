#version 3.7;
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 

#declare LIVE_SCENE=false;
#include "cd.inc"
#include "nut.inc"
#include "hex-spacer.inc"
#include "threaded-rod.inc"
//------------------------------------------------------------------------


#declare CAM_DEFAULT=0;
#declare CAM_ROD_BASE=1;

#declare CAM=0;

camera {
    angle 14
    location  <0, 260, -800>
    look_at <0, 30, 0>

    #switch (CAM)   
        #case (CAM_DEFAULT)
        #break

        #case (CAM_ROD_BASE)
            angle 4
            look_at <-30, 0, 0>
        #break
    
    #end
}

// sun -------------------------------------------------------------------
light_source{<1500,2500,-2500> color White}
// sky -------------------------------------------------------------------
sky_sphere { 
    pigment {
        gradient <0,1,0>
        color_map {
            [0   color rgb<1,1,1>         ]//White
            [0.4 color rgb<0.14,0.14,0.56>]//~Navy
            [0.6 color rgb<0.14,0.14,0.56>]//~Navy
            [1.0 color rgb<1,1,1>         ]//White
        }
        scale 2
    }
}
//------------------------------------------------------------------------




//--------------------------------------------------------------------------
//---------------------------- objects in scene ----------------------------
//--------------------------------------------------------------------------
#declare Level0 = 0;
#declare Level1 = Level0 + 10;
#declare Level2 = Level1 + 50;


union {
    object {CD translate (Level0-CD_THICKNESS)*y}
    object {CD translate (Level1-CD_THICKNESS)*y}
    object {CD translate (Level2-CD_THICKNESS)*y}
    
    
    #declare rod=0;
    #while(rod < 4)
        union {
            object {ThreadedRod(3, 75) translate -10*y} // Rod
            
            object {Nut(3) translate (Level2)*y} // Top CD top nut
            object {Nut(3) translate (Level2-CD_THICKNESS-1.5)*y} // Top CD lower nut
            object {Nut(3) translate Level1*y} // Middle CD upper nut          
            
            object {HexSpacer(3, 8)}
            
            object {Nut(3) translate (Level0-CD_THICKNESS-1.5)*y} // Lower CD lower nut

            translate 50*x
            rotate (rod * 90 + 45) * y
        }

        #declare rod = rod + 1;
    #end

}