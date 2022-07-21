/**
 * @author Maaz Jafrani 20181701072 
 * @version Arduino 1.8.19
 * @since 2022-01-01
 */
//below we are initializing all the variables:
int whiteLed=13;        //since white led's pin is connected to pin 13, hence 13 is assigned to variable whiteLed                                 
int redLed=12;          //red led's pin is connected to pin 12, hence 12 is assigned to variable redLed
int vibrationMotor=11;  //vibrationMotor's pin is 11 on arduino uno so similarly 11 is assigned to the variable vibrationMotor
#include <Servo.h>      //including or importing the Servo library to implement methods and functions from the servo library to make Servo motor work
Servo myservo;          //creating the Servo Library's object to call and use methods and functions included in the <Servo.h> library/package

/* Time Complexity for the constant variables above are:
 *  O(1)
 */

void setup() {
  // put your setup code here, to run once:

  /* Time Complexity for the void setup() function is also:
    *  O(1)
  */
  myservo.attach(9);                // attaches the servo on pin 9 to the servo object
  Serial.begin(9600);               //Serial begin establishes connection between Arduino uno and the device which is (laptop/pc) using usb connection and 9600 is the baud rate at which two devices communicate.
  pinMode(whiteLed,OUTPUT);         //whiteLed or pin 13 set as an Output pin
  pinMode(vibrationMotor,OUTPUT);   //vibartionMotor or pin 11 set as an Output pin
  pinMode(redLed,OUTPUT);           //redLed or pin 12 set as an Output pin
  digitalWrite(vibrationMotor,LOW); //pin 11 or vibrationMotor variable set to LOW or binary 0 initially
  digitalWrite(whiteLed,LOW);       //pin 13 or whiteLed variable set to LOW or binary 0 initially
  digitalWrite(redLed,LOW);         //pin 12 or redLed variable set to LOW or binary 0 initially
}

void loop() {   //In function void loop serial.read() is checked if it is "a,b,c,d,e or f" then the further implementation is done:
  // put your main code here, to run repeatedly:
    /* Time Complexity for the void loop() function is also:

  *  O(1)
  */
    myservo.write(0);  //initially the servo motor will set its postion to 0 degree position or return to 0 degrees after rotating to specified degree
    delay(200);        //returning to 0 degrees with a delay of 200 ms or 0.2 second
   
      if(Serial.available() > 0){                  //checking if there is any string/input available at the serial port or serial buffer. If so then we continue the below steps:
            digitalWrite(redLed,LOW);              //the redLed or pin 12 is turned off or set to LOW or binary 0
            digitalWrite(whiteLed,HIGH);           //the whiteLed or pin 13 is turned on or set to HIGH or binary 1 
            digitalWrite(vibrationMotor,HIGH);     //the vibrationMotor or pin 11 is turned on or set to HIGH or binary 1 
            delay(800);                            //delay is made to be 800 ms or 0.8 sec
            digitalWrite(whiteLed,LOW);            //then after the delay, whiteLed or pin 13 is turned off or set to LOW or binary 0
            digitalWrite(vibrationMotor,LOW);      //the vibrationMotor or pin 11 is also turned off or set to LOW or binary 0 
            
                if(Serial.readString().startsWith("a") ){ //if the string recieved at the serial port by unity starts with or if it is the charachter "a" then further execution is carried out:
                    Serial.setTimeout(100);               //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                    myservo.write(30);                    //servo motor is made to rotate 30 degrees
                    delay(200);                           //servo rotates with the delay of 200 ms or 0.2 sec
                  }

                if(Serial.readString().startsWith("b")){//if the string recieved at the serial port by unity starts with or if it is the charachter "b" then further execution is carried out:
                   Serial.setTimeout(100);              //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                   myservo.write(60);                   //servo motor is made to rotate 60 degrees
                   delay(200);                          //servo rotates with the delay of 200 ms or 0.2 sec
                   }
                if(Serial.readString().startsWith("c")){//if the string recieved at the serial port by unity starts with or if it is the charachter "c" then further execution is carried out:
                    Serial.setTimeout(100);             //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                    myservo.write(90);                  //servo motor is made to rotate 90 degrees
                    delay(200);                         //servo rotates with the delay of 200 ms or 0.2 sec
                  }
                if(Serial.readString().startsWith("d") ){//if the string recieved at the serial port by unity starts with or if it is the charachter "d" then further execution is carried out:
                   Serial.setTimeout(100);               //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                   myservo.write(120);                   //servo motor is made to rotate 120 degrees
                   delay(200);                           //servo rotates with the delay of 200 ms or 0.2 sec
                  }
                if(Serial.readString().startsWith("e")){//if the string recieved at the serial port by unity starts with or if it is the charachter "e" then further execution is carried out:
                   Serial.setTimeout(100);             //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                   myservo.write(150);                 //servo motor is made to rotate 150 degrees
                   delay(200);                         //servo rotates with the delay of 200 ms or 0.2 sec
                }
                if(Serial.readString().startsWith("f")){//if the string recieved at the serial port by unity starts with or if it is the charachter "f" then further execution is carried out:
                 Serial.setTimeout(100);               //solves the problem about recieving output from Unity was slow before. Hence latency is reduced and when ever the collision occurs the output on arduino is on time.
                 myservo.write(180);                   //servo motor is made to rotate 180 degrees
                 delay(200);                           //servo rotates with the delay of 200 ms or 0.2 sec
              } 
      }
        else{        //if serial input is not available at serial port so we will keep the redLed or pin 12 HIGH or turned on.
          digitalWrite(redLed,HIGH);              //the redLed or pin 12 is turned on or set to HIGH or binary 1
            }
}
 /* The overall Time Complexity is:
    *  O(1)
    */
   
