#macro Raster(RScale, HLine) 
    pigment{ gradient x scale RScale
        color_map{
            [0.000   color rgbt<1,1,1,0>*0.6]
            [0+HLine color rgbt<1,1,1,0>*0.6]
            [0+HLine color rgbt<1,1,1,1>]
            [1-HLine color rgbt<1,1,1,1>]
            [1-HLine color rgbt<1,1,1,0>*0.6]
            [1.000   color rgbt<1,1,1,0>*0.6]
        }
    }
#end


#macro Test_Ground()

    #local RasterScale = 10.0;
    #local RasterHalfLine  = 0.02;  
    #local RasterHalfLineZ = 0.02; 

    plane { <0,1,0>, -0.001    // plane with layered textures
            texture { pigment{color <1,1,1>*1.1}
                      finish {ambient 0.45 diffuse 0.85}}
            texture { Raster(RasterScale,RasterHalfLine ) rotate<0,0,0> }
            texture { Raster(RasterScale,RasterHalfLineZ) rotate<0,90,0>}
            rotate<0,0,0>
          }

#end

#macro Test_Sky()
light_source{<1500,2500,-2500> color <1,1,1>}
sky_sphere { 
    pigment {
        gradient <0,1,0>
        color_map {
            [0   color rgb<1,1,1>         ]
            [0.4 color rgb<0.14,0.14,0.56>]
            [0.6 color rgb<0.14,0.14,0.56>]
            [1.0 color rgb<1,1,1>         ]
        }
        scale 2
    }
}
#end