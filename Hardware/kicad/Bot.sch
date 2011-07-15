EESchema Schematic File Version 2  date 14/07/2011 15:36:58
LIBS:power
LIBS:device
LIBS:transistors
LIBS:conn
LIBS:linear
LIBS:regul
LIBS:74xx
LIBS:cmos4000
LIBS:adc-dac
LIBS:memory
LIBS:xilinx
LIBS:special
LIBS:microcontrollers
LIBS:dsp
LIBS:microchip
LIBS:analog_switches
LIBS:motorola
LIBS:texas
LIBS:intel
LIBS:audio
LIBS:interface
LIBS:digital-audio
LIBS:philips
LIBS:display
LIBS:cypress
LIBS:siliconi
LIBS:opto
LIBS:atmel
LIBS:contrib
LIBS:valves
LIBS:Bot
LIBS:Bot-cache
EELAYER 25  0
EELAYER END
$Descr A4 11700 8267
encoding utf-8
Sheet 1 1
Title "Bot"
Date "14 jul 2011"
Rev "1"
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
Text Label 6950 2500 0    60   ~ 0
MOT_R_2
Text Label 6950 2400 0    60   ~ 0
MOT_R_1
Text Label 6950 2300 0    60   ~ 0
MOT_L_2
Text Label 6950 2200 0    60   ~ 0
MOT_L_1
Wire Wire Line
	3200 1500 2600 1500
Connection ~ 2750 1500
Wire Wire Line
	2150 2000 2600 2000
Wire Wire Line
	2600 2000 2600 1500
Wire Wire Line
	2900 3350 2500 3350
Wire Wire Line
	2500 3350 2500 3300
Wire Wire Line
	2500 3300 2150 3300
Wire Wire Line
	2900 3150 2600 3150
Wire Wire Line
	2900 2950 2700 2950
Wire Wire Line
	2700 2950 2700 2900
Wire Wire Line
	2150 1900 2500 1900
Wire Wire Line
	3900 5000 3900 2800
Wire Wire Line
	3900 5000 5800 5000
Wire Wire Line
	4000 4150 4000 2700
Wire Wire Line
	4000 4150 5800 4150
Connection ~ 3100 4450
Connection ~ 2700 4450
Wire Wire Line
	3100 4450 2550 4450
Wire Wire Line
	5250 2550 4200 2550
Wire Wire Line
	4200 2550 4200 2500
Wire Wire Line
	4200 2500 2150 2500
Wire Wire Line
	4300 2300 4300 2250
Wire Wire Line
	4300 2300 2150 2300
Wire Wire Line
	4100 2100 4100 2050
Wire Wire Line
	4100 2100 2150 2100
Wire Wire Line
	5250 2450 4300 2450
Wire Wire Line
	2600 3150 2600 3100
Wire Wire Line
	2600 3100 2150 3100
Wire Wire Line
	2700 2900 2150 2900
Wire Wire Line
	5700 5200 5700 5100
Wire Wire Line
	5700 5100 5800 5100
Wire Wire Line
	5800 4900 5700 4900
Wire Wire Line
	5700 4900 5700 4800
Wire Wire Line
	4000 2700 2150 2700
Wire Wire Line
	7600 2300 6750 2300
Wire Wire Line
	6750 2300 6750 2200
Wire Wire Line
	6750 2200 6650 2200
Wire Wire Line
	7600 2500 6850 2500
Wire Wire Line
	6850 2500 6850 2600
Connection ~ 6000 3350
Wire Wire Line
	6100 3350 5800 3350
Wire Wire Line
	6100 3350 6100 3250
Connection ~ 5900 3350
Wire Wire Line
	5900 3350 5900 3250
Wire Wire Line
	6850 2600 6650 2600
Wire Wire Line
	5700 3950 5700 4050
Wire Wire Line
	2500 1900 2500 1150
Wire Wire Line
	5700 4050 5800 4050
Wire Wire Line
	5800 4250 5700 4250
Wire Wire Line
	5700 4250 5700 4350
Wire Wire Line
	6650 2500 6750 2500
Wire Wire Line
	5800 3350 5800 3250
Wire Wire Line
	5950 3350 5950 3450
Wire Wire Line
	6000 3250 6000 3350
Connection ~ 5950 3350
Wire Wire Line
	6750 2500 6750 2400
Wire Wire Line
	6750 2400 7600 2400
Wire Wire Line
	6650 2100 6850 2100
Wire Wire Line
	6850 2100 6850 2200
Wire Wire Line
	6850 2200 7600 2200
Wire Wire Line
	2150 3000 2650 3000
Wire Wire Line
	2550 4450 2550 3800
Wire Wire Line
	4100 2050 5250 2050
Wire Wire Line
	5250 2150 4200 2150
Wire Wire Line
	4300 2250 5250 2250
Wire Wire Line
	4200 2150 4200 2200
Wire Wire Line
	4200 2200 2150 2200
Wire Wire Line
	2150 2400 4300 2400
Wire Wire Line
	4300 2400 4300 2450
Wire Wire Line
	5250 2650 4100 2650
Wire Wire Line
	4100 2650 4100 2600
Wire Wire Line
	4100 2600 2150 2600
Wire Wire Line
	2500 1150 3200 1150
Connection ~ 2750 1150
Connection ~ 3100 1150
Wire Wire Line
	6250 1600 6250 1500
Connection ~ 3100 1500
Wire Wire Line
	2700 4500 2700 4450
Wire Wire Line
	2550 3800 2150 3800
Wire Wire Line
	2650 3000 2650 3050
Wire Wire Line
	2650 3050 2900 3050
Wire Wire Line
	2150 3200 2550 3200
Wire Wire Line
	2550 3200 2550 3250
Wire Wire Line
	2550 3250 2900 3250
Wire Wire Line
	2150 3400 2450 3400
Wire Wire Line
	2450 3400 2450 3450
Wire Wire Line
	2450 3450 2900 3450
Wire Wire Line
	3900 2800 2150 2800
Wire Wire Line
	5650 1600 5650 1500
$Comp
L VCC #PWR01
U 1 1 4E1EDD44
P 6250 1500
F 0 "#PWR01" H 6250 1600 30  0001 C CNN
F 1 "VCC" H 6250 1600 30  0000 C CNN
	1    6250 1500
	1    0    0    -1  
$EndComp
$Comp
L +5V #PWR02
U 1 1 4E1EDD3D
P 5650 1500
F 0 "#PWR02" H 5650 1590 20  0001 C CNN
F 1 "+5V" H 5650 1590 30  0000 C CNN
	1    5650 1500
	1    0    0    -1  
$EndComp
NoConn ~ 2900 2950
NoConn ~ 2900 3050
NoConn ~ 2900 3150
NoConn ~ 2900 3250
NoConn ~ 2900 3350
NoConn ~ 2900 3450
NoConn ~ 2150 3700
NoConn ~ 2150 3600
NoConn ~ 2150 3500
Text Label 2900 3450 0    50   ~ 0
Arduino PWM 6
Text Label 2900 3350 0    50   ~ 0
Arduino PWM 5
Text Label 2900 3250 0    50   ~ 0
Arduino 4
Text Label 2900 3150 0    50   ~ 0
Arduino 3
Text Label 2900 3050 0    50   ~ 0
Arduino TX 1
Text Label 2900 2950 0    50   ~ 0
Arduino RX 0
$Comp
L CONN_20 P1
U 1 1 4E1EDB91
P 1800 2850
F 0 "P1" V 1750 2850 60  0000 C CNN
F 1 "ARDUINO" V 1850 2850 60  0000 C CNN
	1    1800 2850
	-1   0    0    -1  
$EndComp
Text Label 4950 5000 0    50   ~ 0
Arduino PWM 10
Text Label 5300 4150 0    50   ~ 0
Aduino 2
$Comp
L GND #PWR03
U 1 1 4E1EDA7C
P 5950 3450
F 0 "#PWR03" H 5950 3450 30  0001 C CNN
F 1 "GND" H 5950 3380 30  0001 C CNN
	1    5950 3450
	1    0    0    -1  
$EndComp
Text Label 3200 1500 0    50   ~ 0
Arduino Vin
Text Label 3200 1150 0    50   ~ 0
Arduino +5V
Text Label 2600 4450 0    50   ~ 0
Arduino GND
Text Label 4150 2650 0    50   ~ 0
Arduino 13
Text Label 4250 2550 0    50   ~ 0
Arduino 12
Text Label 4350 2450 0    50   ~ 0
Arduino PWM 11
Text Label 4300 2250 0    50   ~ 0
Arduino 8
Text Label 4200 2150 0    50   ~ 0
Arduino 7
Text Label 4100 2050 0    50   ~ 0
Arduino PWM 9
$Comp
L +5V #PWR04
U 1 1 4E15E320
P 5700 4800
F 0 "#PWR04" H 5700 4890 20  0001 C CNN
F 1 "+5V" H 5700 4890 30  0000 C CNN
	1    5700 4800
	1    0    0    -1  
$EndComp
$Comp
L CONN_3 K3
U 1 1 4E15E31F
P 6150 5000
F 0 "K3" V 6100 5000 50  0000 C CNN
F 1 "SERVO" V 6200 5000 40  0000 C CNN
	1    6150 5000
	1    0    0    -1  
$EndComp
$Comp
L GND #PWR05
U 1 1 4E15E31E
P 5700 5200
F 0 "#PWR05" H 5700 5200 30  0001 C CNN
F 1 "GND" H 5700 5130 30  0001 C CNN
	1    5700 5200
	1    0    0    -1  
$EndComp
Text Notes 6400 5000 0    60   ~ 0
Head Movement
Text Notes 1550 3350 1    60   ~ 0
Master Connections
Text Notes 8200 2400 0    60   ~ 0
Wheel Control
Text Notes 6400 4200 0    60   ~ 0
Object Detection
$Comp
L PWR_FLAG #FLG06
U 1 1 4E15E14D
P 3100 1500
F 0 "#FLG06" H 3100 1770 30  0001 C CNN
F 1 "PWR_FLAG" H 3100 1730 30  0000 C CNN
	1    3100 1500
	1    0    0    -1  
$EndComp
$Comp
L VCC #PWR07
U 1 1 4E15E12E
P 2750 1500
F 0 "#PWR07" H 2750 1600 30  0001 C CNN
F 1 "VCC" H 2750 1600 30  0000 C CNN
	1    2750 1500
	1    0    0    -1  
$EndComp
$Comp
L +5V #PWR08
U 1 1 4E15E117
P 2750 1150
F 0 "#PWR08" H 2750 1240 20  0001 C CNN
F 1 "+5V" H 2750 1240 30  0000 C CNN
	1    2750 1150
	1    0    0    -1  
$EndComp
$Comp
L SN754410 H1
U 1 1 4E15AF7A
P 5950 2950
F 0 "H1" V 6000 3600 60  0000 C CNN
F 1 "SN754410" V 5900 3600 60  0000 C CNN
	1    5950 2950
	1    0    0    -1  
$EndComp
$Comp
L CONN_4 P2
U 1 1 4E15B023
P 7950 2350
F 0 "P2" V 7900 2350 50  0000 C CNN
F 1 "MOTORS" V 8000 2350 50  0000 C CNN
	1    7950 2350
	1    0    0    -1  
$EndComp
$Comp
L PWR_FLAG #FLG09
U 1 1 4E159BD4
P 3100 4450
F 0 "#FLG09" H 3100 4720 30  0001 C CNN
F 1 "PWR_FLAG" H 3100 4680 30  0000 C CNN
	1    3100 4450
	1    0    0    1   
$EndComp
$Comp
L GND #PWR010
U 1 1 4E159BC0
P 2700 4500
F 0 "#PWR010" H 2700 4500 30  0001 C CNN
F 1 "GND" H 2700 4430 30  0001 C CNN
	1    2700 4500
	1    0    0    -1  
$EndComp
$Comp
L GND #PWR011
U 1 1 4E15672C
P 5700 4350
F 0 "#PWR011" H 5700 4350 30  0001 C CNN
F 1 "GND" H 5700 4280 30  0001 C CNN
	1    5700 4350
	1    0    0    -1  
$EndComp
$Comp
L CONN_3 K1
U 1 1 4E1566F9
P 6150 4150
F 0 "K1" V 6100 4150 50  0000 C CNN
F 1 "PING)))" V 6200 4150 40  0000 C CNN
	1    6150 4150
	1    0    0    -1  
$EndComp
$Comp
L PWR_FLAG #VCC012
U 1 1 4E139DC9
P 3100 1150
F 0 "#VCC012" H 3100 1420 30  0001 C CNN
F 1 "PWR_FLAG" H 3100 1380 30  0000 C CNN
	1    3100 1150
	1    0    0    -1  
$EndComp
$Comp
L +5V #PWR013
U 1 1 4E139D79
P 5700 3950
F 0 "#PWR013" H 5700 4040 20  0001 C CNN
F 1 "+5V" H 5700 4040 30  0000 C CNN
	1    5700 3950
	1    0    0    -1  
$EndComp
$EndSCHEMATC
