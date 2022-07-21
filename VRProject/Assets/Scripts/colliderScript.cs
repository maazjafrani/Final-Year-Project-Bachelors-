/**
 * @author Maaz Jafrani
 * @since 2022/01/01
 * @version 1.0
 * 
 */

//below importing all the required libraries:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; //Contains classes for controlling serial ports. The most important class, SerialPort, provides a framework for synchronous and event-driven I/O.
/*
 *force will be calculated on each object using f=k*x; where k is the constant stiffness for each object and x is the change 
 *in postion of cube when it is pressed using leap hands from the top of cube(y position)
*/
public class colliderScript : MonoBehaviour
{  
    //initiallizing variables for just "Cube1" below:
    float ForceCube1= 0.0f;                     //initializing force to 0.0 initially
    public Vector3 tempCube1;                   //initializing temp variable to get and store position of cube in it
    float initialYPositionCube1 = -0.007000001f;//intial position of cube's y axis when it is stationary on the table intially
    float kCube1 = 1000.0f;                     //stifness set 
    float xposCube1= 0.0f;                      //initial difference would be 0
    //initiallizing variables for just "Cube2" below:
    float ForceCube2 = 0.0f;                    //initializing force to 0.0 initially
    public Vector3 tempCube2;                   //initializing temp variable to get and store position of cube in it
    float initialYPositionCube2 = -0.007000002f;//intial position of cube's y axis when it is stationary on the table intially
    float kCube2 = 500.0f;                      //stifness set 
    float xposCube2 = 0.0f;                     //initial difference would be 0
    //initiallizing variables for just "Cube2" below:
    float ForceCube3 = 0.0f;                    //initializing force to 0.0 initially
    public Vector3 tempCube3;                   //initializing temp variable to get and store position of cube in it
    float initialYPositionCube3 = -0.007000007f;//intial position of cube's y axis when it is stationary on the table intially
    float kCube3 = 1200.0f;                     //stifness set 
    float xposCube3 = 0.0f;                     //initial difference would be 0
    /*
     * "Cube3" has highest stiffness so it will make the servo motor rotate the maximum. as since k is more so force applied would be more too
     * hence the deformation of cube will be more hence servo will rotate more.
     * "Cube2" has lowest stiffness so it will make the servo motor rotate the minimum. as since k is less so force applied would be less too
     * hence the deformation of cube will be less hence servo will rotate the least among the 3 cubes.
     */

    /*
     * All cubes when pressed from the top would rotate the servo motor, make the white led and also the vibration motor work on the arduino.
     */
    SerialPort sp = new SerialPort("COM4", 9600); // Serial Port class is used and an object "sp" is created by defining "COM4" as the serial or usb port with the baud rate 9600
   
    /* Time Complexity for the constant variables above are:
     *  O(1)
     */
    // Start is called before the first frame update
    void Start()            //start() method:
    {
                            /* Time Complexity for Start() function is:
                             * O(1)
                             */
        
        sp.Open();          //initially the the serial port at "COM4" is opened so that output from unity could be sent to the arduino ide
        sp.ReadTimeout = 1; //Gets or sets the number of milliseconds before a time-out occurs when a read operation does not finish.

    }

    // Update is called once per frame
    void Update()
    {
        /* Time Complexity also for the Update() function is also:
        * O(1)
        */
        //Working for Cube1 below:
        tempCube1 = GameObject.Find("Cube1").transform.position; //storing current value of postion of cube1 to the temp1 variable in at each frame.
        xposCube1 = (initialYPositionCube1 - tempCube1.y);       //calculating "x" the difference for cube1 at each frame
        ForceCube1 = kCube1 * xposCube1;                         //calulating force at each frame.
        //Debug.Log(ForceCube1); //printing force exerted on cube in each frame
        //Working for Cube2 below:
        tempCube2 = GameObject.Find("Cube2").transform.position; //storing current value of postion of cube2 to the temp variable in at each frame.
        xposCube2 = (initialYPositionCube2 - tempCube2.y);       //calculating "x" the difference for cube2 at each frame
        ForceCube2 = kCube2 * xposCube2;                         //calulating force at each frame.
        //Debug.Log(ForceCube2); //printing force exerted on cube in each frame
        //Working for Cube3 below:
        tempCube3 = GameObject.Find("Cube3").transform.position; //storing current value of postion of cube3 to the temp variable in at each frame.
        xposCube3 = (initialYPositionCube3 - tempCube3.y);       //calculating "x" the difference for cube3 at each frame
        ForceCube3 = kCube3 * xposCube3;                         //calulating force at each frame.
        // Debug.Log(ForceCube3); //printing force exerted on cube in each frame
        if (sp.IsOpen)  //checking if serialport IsOpen is true then:
            {
                //Below is the working for just "Cube1" Cube 1 will rotate 30 60 90 and 120 degrees
                //cube 1 has stiffness k=1000

               /*below values within if conditions are set within some tested ranges for "force", inorder to not to make the serial port busy or
                * to cause in any delay when serialport write charachters to the serial port at "COM4". Because otherwise the servo motor 
                * doesnt seem to rotate if we set the values for forces within, for example, a wide or the smallest range.
                * Hence, All the range for forces below are tested to achieve the best output on the arduino/servo motor.
                */
                if (ForceCube1 >= 1 && ForceCube1 <= 1.2)
                {
                    sp.Write("a");               //rotating servo motor 30 degrees/ sending "a" char to the serial port or to arduino ide
                    Debug.Log("a");              //printing "a" to the unity console

                }
                if (ForceCube1 >= 4 && ForceCube1 <= 4.2)
                {
                    sp.Write("b");               //rotating servo motor 60 degrees/ sending "b" char to the serial port or to arduino ide
                    Debug.Log("b");              //printing "b" to the unity console

                }
            
                if (ForceCube1 > 7 && ForceCube1 <= 7.2)
                {
                    sp.WriteLine("c");          //rotating servo motor 90 degrees/ sending "c" char to the serial port or to arduino ide
                    Debug.Log("c");             //printing "c" to the unity console

                }

                if (ForceCube1 > 10 && ForceCube1 <= 10.2)
                {
                    sp.WriteLine("d");            //rotating servo motor 120 degrees/ sending "d" char to the serial port or to arduino ide
                    Debug.Log("d");               //printing "d" to the unity console

                }

            //below is the working for "Cube2": Cube 2 will rotate 30 and 60 degrees
            //cube 2 has stiffness k=500. least stiffness so it will make servo rotate also less

            /*below values within if conditions are set within some tested ranges for "force", inorder to not to make the serial port busy or
             * to cause in any delay when serialport write charachters to the serial port at "COM4". Because otherwise the servo motor 
             * doesnt seem to rotate if we set the values for forces within, for example, a wide or the smallest range.
             * Hence, All the range for forces below are tested to achieve the best output on the arduino/servo motor.
             */

                if (ForceCube2 >= 1 && ForceCube2 <= 1.2)
                {
                    sp.Write("a");               //rotating servo motor 30 degrees/ sending "a" char to the serial port or to arduino ide
                    Debug.Log("a");              //printing "a" to the unity console

                }
                if (ForceCube2 >= 4 && ForceCube2 <= 4.3)
                {
                    sp.Write("b");               //rotating servo motor 60 degrees/ sending "b" char to the serial port or to arduino ide
                    Debug.Log("b");              //printing "b" to the unity console

                }
            //Below is the working for just "Cube3" Cube 3 will rotate 30 60 90 120 150 and 180 degrees because
            //it has the highest K (Stiffness) which is 1200
            /*below values within if conditions are set within some tested ranges for "force", inorder to not to make the serial port busy or
             * to cause in any delay when serialport write charachters to the serial port at "COM4". Because otherwise the servo motor 
             * doesnt seem to rotate if we set the values for forces within, for example, a wide or the smallest range.
             * Hence, All the range for forces below are tested to achieve the best output on the arduino/servo motor.
             */

                if (ForceCube3 >= 1 && ForceCube3 <= 1.3)
                {
                    sp.Write("a");               //rotating servo motor 30 degrees/ sending "a" char to the serial port or to arduino ide
                    Debug.Log("a");              //printing "a" to the unity console

                }
                if (ForceCube3 >= 4 && ForceCube3 <= 4.2)
                {
                    sp.Write("b");               //rotating servo motor 60 degrees/ sending "b" char to the serial port or to arduino ide
                    Debug.Log("b");              //printing "b" to the unity console

                }
                if (ForceCube3 > 7 && ForceCube3 <= 7.3)
                {
                    sp.WriteLine("c");            //rotating servo motor 90 degrees/ sending "c" char to the serial port or to arduino ide
                    Debug.Log("c");               //printing "c" to the unity console

                }

                if (ForceCube3 > 10 && ForceCube3 <= 10.2)
                {
                    sp.WriteLine("d");            //rotating servo motor 120 degrees/ sending "d" char to the serial port or to arduino ide
                    Debug.Log("d");               //printing "d" to the unity console

                }

                if (ForceCube3 > 13 && ForceCube3 <= 13.3)
                {
                    sp.WriteLine("e");            //rotating servo motor 150 degrees/ sending "e" char to the serial port or to arduino ide
                    Debug.Log("e");               //printing "e" to the unity console

                }
                if (ForceCube3 > 16 && ForceCube3 <= 16.3)
                {
                    sp.WriteLine("f");            //rotating servo motor 180 degrees/ sending "f" char to the serial port or to arduino ide
                    Debug.Log("f");               //printing "f" to the unity console

                }
            }
}

}
/* Time Complexity for overall code is:
 * O(1)
 */
