EESchema Schematic File Version 2  date 07/07/2011 12:49:16
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
EELAYER 25  0
EELAYER END
$Descr A4 11700 8267
encoding utf-8
Sheet 1 1
Title ""
Date "7 jul 2011"
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
Wire Wire Line
	7600 1800 7700 1800
Wire Wire Line
	7700 1800 7700 1850
Wire Wire Line
	7700 1850 7800 1850
Wire Wire Line
	7600 1500 8800 1500
Wire Wire Line
	4600 1600 4500 1600
Wire Wire Line
	4500 1600 4500 1800
Wire Wire Line
	4500 1800 4350 1800
Wire Wire Line
	4600 1450 4450 1450
Wire Wire Line
	4450 1450 4450 1700
Connection ~ 8300 1500
Wire Wire Line
	7700 1500 7700 1750
Wire Wire Line
	7700 1750 7800 1750
Wire Wire Line
	8700 1850 8900 1850
Wire Wire Line
	8800 1500 8800 1750
Wire Wire Line
	8800 1750 8900 1750
Wire Wire Line
	8900 1950 8800 1950
Wire Wire Line
	8800 1950 8800 2050
Wire Wire Line
	7700 2150 7700 2050
Wire Wire Line
	4450 1700 4350 1700
Wire Wire Line
	4350 2600 4700 2600
Wire Wire Line
	4700 2600 4700 2700
Connection ~ 4500 2600
Wire Wire Line
	4350 1900 4550 1900
Wire Wire Line
	4550 1900 4550 1750
Wire Wire Line
	4550 1750 4600 1750
Connection ~ 4500 1450
Connection ~ 8300 1500
Connection ~ 7700 1500
Wire Wire Line
	7700 2050 7800 2050
Wire Wire Line
	7800 1950 7700 1950
Wire Wire Line
	7700 1950 7700 2000
Wire Wire Line
	7700 2000 7600 2000
Text GLabel 7600 2000 0    60   Input ~ 0
D3
$Comp
L CONN_4 P?
U 1 1 4E159CF7
P 8150 1900
F 0 "P?" V 8100 1900 50  0000 C CNN
F 1 "CONN_4" V 8200 1900 50  0000 C CNN
	1    8150 1900
	1    0    0    -1  
$EndComp
Text GLabel 7600 1500 0    60   Input ~ 0
5V
Text GLabel 4600 1450 2    60   Input ~ 0
5V
$Comp
L PWR_FLAG #FLG01
U 1 1 4E159BD4
P 4500 2600
F 0 "#FLG01" H 4500 2870 30  0001 C CNN
F 1 "PWR_FLAG" H 4500 2830 30  0000 C CNN
	1    4500 2600
	1    0    0    1   
$EndComp
$Comp
L GND #PWR02
U 1 1 4E159BC0
P 4700 2700
F 0 "#PWR02" H 4700 2700 30  0001 C CNN
F 1 "GND" H 4700 2630 30  0001 C CNN
	1    4700 2700
	1    0    0    -1  
$EndComp
NoConn ~ 4350 2500
NoConn ~ 4350 2400
NoConn ~ 4350 2300
NoConn ~ 4350 2200
NoConn ~ 4350 2100
NoConn ~ 4350 2000
Text GLabel 4600 1750 2    60   Input ~ 0
D2
Text GLabel 4600 1600 2    60   Input ~ 0
D1
Text GLabel 7600 1800 0    60   Input ~ 0
D2
$Comp
L GND #PWR03
U 1 1 4E159ADB
P 7700 2150
F 0 "#PWR03" H 7700 2150 30  0001 C CNN
F 1 "GND" H 7700 2080 30  0001 C CNN
	1    7700 2150
	1    0    0    -1  
$EndComp
$Comp
L CONN_10 P1
U 1 1 4E158BEF
P 4000 2150
F 0 "P1" V 3950 2150 60  0000 C CNN
F 1 "ARDUINO" V 4050 2150 60  0000 C CNN
	1    4000 2150
	-1   0    0    -1  
$EndComp
Text GLabel 8700 1850 0    60   Input ~ 0
D1
$Comp
L GND #PWR04
U 1 1 4E15672C
P 8800 2050
F 0 "#PWR04" H 8800 2050 30  0001 C CNN
F 1 "GND" H 8800 1980 30  0001 C CNN
	1    8800 2050
	1    0    0    -1  
$EndComp
$Comp
L CONN_3 K1
U 1 1 4E1566F9
P 9250 1850
F 0 "K1" V 9200 1850 50  0000 C CNN
F 1 "PING)))" V 9300 1850 40  0000 C CNN
	1    9250 1850
	1    0    0    -1  
$EndComp
$Comp
L PWR_FLAG #VCC05
U 1 1 4E139DC9
P 4500 1450
F 0 "#VCC05" H 4500 1720 30  0001 C CNN
F 1 "PWR_FLAG" H 4500 1680 30  0000 C CNN
	1    4500 1450
	1    0    0    -1  
$EndComp
$Comp
L +5V #PWR06
U 1 1 4E139D79
P 8300 1500
F 0 "#PWR06" H 8300 1590 20  0001 C CNN
F 1 "+5V" H 8300 1590 30  0000 C CNN
	1    8300 1500
	1    0    0    -1  
$EndComp
$EndSCHEMATC
