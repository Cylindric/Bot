EESchema Schematic File Version 2  date 06/07/2011 00:27:16
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
LIBS:Bot-cache
EELAYER 25  0
EELAYER END
$Descr A4 11700 8267
encoding utf-8
Sheet 1 1
Title ""
Date "5 jul 2011"
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
Connection ~ 7250 1500
$Comp
L PWR_FLAG #VCC01
U 1 1 4E139DC9
P 7250 1500
F 0 "#VCC01" H 7250 1770 30  0001 C CNN
F 1 "PWR_FLAG" H 7250 1730 30  0000 C CNN
	1    7250 1500
	1    0    0    -1  
$EndComp
Connection ~ 4400 1500
$Comp
L +9V #PWR02
U 1 1 4E139DB5
P 4400 1500
F 0 "#PWR02" H 4400 1470 20  0001 C CNN
F 1 "+9V" H 4400 1610 30  0000 C CNN
	1    4400 1500
	1    0    0    -1  
$EndComp
Connection ~ 6900 1500
$Comp
L +5V #PWR03
U 1 1 4E139D79
P 6900 1500
F 0 "#PWR03" H 6900 1590 20  0001 C CNN
F 1 "+5V" H 6900 1590 30  0000 C CNN
	1    6900 1500
	1    0    0    -1  
$EndComp
Connection ~ 4700 1500
Connection ~ 5100 3350
Wire Wire Line
	4250 1500 5150 1500
Wire Wire Line
	6150 3000 6250 3000
Wire Wire Line
	4250 3350 6900 3350
Wire Wire Line
	6250 3000 6250 2900
Connection ~ 6250 2300
Wire Wire Line
	6250 2200 6250 2400
Wire Wire Line
	6250 1600 6250 1500
Wire Wire Line
	6950 2300 6850 2300
Wire Wire Line
	7550 2400 7550 2200
Wire Wire Line
	4850 2300 4850 2600
Wire Wire Line
	4850 2600 3850 2600
Wire Wire Line
	3950 1600 4250 1600
Wire Wire Line
	4250 2100 4250 2000
Wire Wire Line
	3850 2300 3950 2300
Wire Wire Line
	4250 3450 4250 2500
Wire Wire Line
	4250 1600 4250 1500
Wire Wire Line
	4250 2000 3950 2000
Wire Wire Line
	4850 2000 5150 2000
Wire Wire Line
	5150 1500 5150 1600
Wire Wire Line
	5150 2000 5150 2100
Wire Wire Line
	5150 1600 4850 1600
Wire Wire Line
	5150 2500 5150 2750
Wire Wire Line
	5150 2750 4250 2750
Connection ~ 4250 2750
Connection ~ 4250 3350
Wire Wire Line
	6350 2300 6250 2300
Wire Wire Line
	7550 1600 7550 1500
Wire Wire Line
	7450 2300 7550 2300
Connection ~ 7550 2300
Wire Wire Line
	6900 3350 6900 2300
Connection ~ 6900 2300
Wire Wire Line
	3350 2300 3250 2300
Wire Wire Line
	3250 2600 3350 2600
Wire Wire Line
	7550 2900 7550 3000
Wire Wire Line
	7550 1500 6250 1500
Wire Wire Line
	7550 3000 7450 3000
$Comp
L CONN_1 P9
U 1 1 4E10CB2E
P 3100 2600
F 0 "P9" H 3180 2600 40  0000 L CNN
F 1 "CONN_1" H 3100 2655 30  0001 C CNN
	1    3100 2600
	-1   0    0    1   
$EndComp
$Comp
L CONN_1 P10
U 1 1 4E10CB2C
P 3100 2300
F 0 "P10" H 3180 2300 40  0000 L CNN
F 1 "CONN_1" H 3100 2355 30  0001 C CNN
	1    3100 2300
	-1   0    0    1   
$EndComp
$Comp
L PWR_FLAG #VCC04
U 1 1 4E10CA30
P 4700 1500
F 0 "#VCC04" H 4700 1770 30  0001 C CNN
F 1 "PWR_FLAG" H 4700 1730 30  0000 C CNN
	1    4700 1500
	1    0    0    -1  
$EndComp
$Comp
L PWR_FLAG #GND05
U 1 1 4E10C99C
P 5100 3350
F 0 "#GND05" H 5100 3620 30  0001 C CNN
F 1 "PWR_FLAG" H 5100 3580 30  0000 C CNN
	1    5100 3350
	-1   0    0    1   
$EndComp
$Comp
L CONN_1 P3
U 1 1 4E10C946
P 7300 3000
F 0 "P3" H 7380 3000 40  0000 L CNN
F 1 "CONN_1" H 7300 3055 30  0001 C CNN
	1    7300 3000
	-1   0    0    1   
$EndComp
$Comp
L CONN_1 P2
U 1 1 4E10C93F
P 6000 3000
F 0 "P2" H 6080 3000 40  0000 L CNN
F 1 "CONN_1" H 6000 3055 30  0001 C CNN
	1    6000 3000
	-1   0    0    1   
$EndComp
$Comp
L R R3
U 1 1 4E10C7E0
P 6250 2650
F 0 "R3" V 6330 2650 50  0000 C CNN
F 1 "560" V 6250 2650 50  0000 C CNN
	1    6250 2650
	-1   0    0    1   
$EndComp
$Comp
L SW_PUSH SW1
U 1 1 4E10C792
P 6250 1900
F 0 "SW1" H 6400 2010 50  0000 C CNN
F 1 "Left Antenna" H 6250 1820 50  0000 C CNN
	1    6250 1900
	0    1    1    0   
$EndComp
$Comp
L R R6
U 1 1 4E10C76B
P 7550 2650
F 0 "R6" V 7630 2650 50  0000 C CNN
F 1 "560" V 7550 2650 50  0000 C CNN
	1    7550 2650
	-1   0    0    1   
$EndComp
$Comp
L R R4
U 1 1 4E10C70C
P 6600 2300
F 0 "R4" V 6680 2300 50  0000 C CNN
F 1 "560" V 6600 2300 50  0000 C CNN
	1    6600 2300
	0    -1   -1   0   
$EndComp
$Comp
L R R5
U 1 1 4E10C6F5
P 7200 2300
F 0 "R5" V 7280 2300 50  0000 C CNN
F 1 "560" V 7200 2300 50  0000 C CNN
	1    7200 2300
	0    -1   -1   0   
$EndComp
$Comp
L SW_PUSH SW2
U 1 1 4E10C693
P 7550 1900
F 0 "SW2" H 7700 2010 50  0000 C CNN
F 1 "Right Antenna" H 7550 1820 50  0000 C CNN
	1    7550 1900
	0    1    1    0   
$EndComp
$Comp
L BC237 Q2
U 1 1 4E108A0B
P 5050 2300
F 0 "Q2" H 5250 2200 50  0000 C CNN
F 1 "P2N2222A" H 5400 2350 50  0000 C CNN
F 2 "TO92-EBC" H 5240 2300 30  0001 C CNN
	1    5050 2300
	1    0    0    -1  
$EndComp
$Comp
L R R2
U 1 1 4E108A0A
P 3600 2600
F 0 "R2" V 3680 2600 50  0000 C CNN
F 1 "2.2K" V 3600 2600 50  0000 C CNN
	1    3600 2600
	0    1    1    0   
$EndComp
$Comp
L MOTOR M2
U 1 1 4E108A08
P 5150 1800
F 0 "M2" H 5250 1950 60  0000 C CNN
F 1 "Right Wheel" V 5350 1800 60  0000 C CNN
	1    5150 1800
	1    0    0    -1  
$EndComp
$Comp
L DIODE D2
U 1 1 4E108A06
P 4850 1800
F 0 "D2" H 4850 1900 40  0000 C CNN
F 1 "1N4001" H 4850 1700 40  0000 C CNN
	1    4850 1800
	0    -1   -1   0   
$EndComp
$Comp
L DIODE D1
U 1 1 4E108750
P 3950 1800
F 0 "D1" H 3950 1900 40  0000 C CNN
F 1 "1N4001" H 3950 1700 40  0000 C CNN
	1    3950 1800
	0    -1   -1   0   
$EndComp
$Comp
L MOTOR M1
U 1 1 4E1085FF
P 4250 1800
F 0 "M1" H 4350 1950 60  0000 C CNN
F 1 "Left Wheel" V 4450 1800 60  0000 C CNN
	1    4250 1800
	1    0    0    -1  
$EndComp
$Comp
L GND #PWR06
U 1 1 4E108510
P 4250 3450
F 0 "#PWR06" H 4250 3450 30  0001 C CNN
F 1 "GND" H 4250 3380 30  0001 C CNN
	1    4250 3450
	1    0    0    -1  
$EndComp
$Comp
L R R1
U 1 1 4E1084E4
P 3600 2300
F 0 "R1" V 3680 2300 50  0000 C CNN
F 1 "2.2K" V 3600 2300 50  0000 C CNN
	1    3600 2300
	0    1    1    0   
$EndComp
$Comp
L BC237 Q1
U 1 1 4E1084CF
P 4150 2300
F 0 "Q1" H 4350 2200 50  0000 C CNN
F 1 "P2N2222A" H 4500 2350 50  0000 C CNN
F 2 "TO92-EBC" H 4340 2300 30  0001 C CNN
	1    4150 2300
	1    0    0    -1  
$EndComp
$EndSCHEMATC
